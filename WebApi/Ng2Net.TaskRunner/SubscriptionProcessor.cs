using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Reflection;
using Ng2Net.Model.Scheduler;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastrucure.Logging;
using Ng2Net.Model.Business;
using Ng2Net.Data;
using Ng2Net.Model.Security;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Services;

namespace Ng2Net.TaskRunner
{
    class SubscriptionProcessor
    {
        public int SuccessfulNotifications { get; set; }
        public int FailedNotifications { get; set; }
        public int TotalNotifications { get; set; }
        private IRepository<Proposal> _repository;
        private IRepository<TaskRunnerLog> _taskRunnerLogRepository;
        private DatabaseContext _dc;
        private SubscriptionProcessorSettings _settings;
        private INotificationService _notificationService;
        private IHtmlContentService _contentService;

        public SubscriptionProcessor(IRepository<Proposal> repository, IRepository<TaskRunnerLog> taskRunnerLogRepository, SubscriptionProcessorSettings settings, INotificationService notificationService, IHtmlContentService contentService)
        {
            this._repository = repository;
            this._dc = new DatabaseContext();
            this._settings = settings;
            this._taskRunnerLogRepository = taskRunnerLogRepository;
            this._notificationService = notificationService;
            this._contentService = contentService;
        }

        public string LogFileName { get; set; }

        public int ProcessQueue()
        {

            Dictionary<string, List<Proposal>> dictProposalsForUsers = new Dictionary<string, List<Proposal>>();

            TaskRunnerLog lastRun = _taskRunnerLogRepository.GetMany(l => l.TaskName == "ProcessSubscriptions" && l.TaskResult.ToUpper() == "COMPLETE").OrderByDescending(l => l.DateStarted).FirstOrDefault();
            DateTime dReferenceDate = lastRun!=null ? lastRun.DateStarted : DateTime.MinValue;

            List<Proposal> lstProposals = this._repository.GetMany(x => x.StartDate > dReferenceDate && x.LimitDate > DateTime.Now).ToList();

            List<ApplicationUser> lstUsersSubscribedToAll = _dc.Users.Where(x => x.SubscriptionType == "ALL" && x.EmailConfirmed).ToList();
            foreach (ApplicationUser xApplicationUser in lstUsersSubscribedToAll)
            {
                dictProposalsForUsers.Add(xApplicationUser.Id, lstProposals);
            }

            List<ApplicationUser> lstUserFromProposals = new List<ApplicationUser>();
            foreach(Proposal xProposal in lstProposals)
            {
                foreach(ApplicationUser xUser in xProposal.Institution.SubscribedUsers.Where(u=>u.EmailConfirmed && u.SubscriptionType == "SELECTED"))
                {
                    if (!dictProposalsForUsers.ContainsKey(xUser.Id))
                    {
                        dictProposalsForUsers.Add(xUser.Id, new List<Proposal>());
                        lstUserFromProposals.Add(xUser);
                    }

                    dictProposalsForUsers[xUser.Id].Add(xProposal);
                }
            }

            List<ApplicationUser> lstAllUsers = new List<ApplicationUser>();
            lstAllUsers.AddRange(lstUsersSubscribedToAll);
            lstAllUsers.AddRange(lstUserFromProposals);

            //add to notification table
            foreach (KeyValuePair<string, List<Proposal>> entry in dictProposalsForUsers.Where(p=>p.Value.Count()>0))
            {
                AddToNotification(lstAllUsers.Find(x=>x.Id==entry.Key),entry.Value);
            }
            return this.SuccessfulNotifications;
        }

        private void AddToNotification(ApplicationUser xUser, List<Proposal> lstProposal)
        {
            Dictionary<string, string> replacements = new Dictionary<string, string>();
            replacements.Add("FULLNAME", xUser.FirstName + " " + xUser.LastName);
            replacements.Add("PROPOSALCOUNT", lstProposal.ToString());

            string proposalsContent = "";
            foreach (Proposal xProposal in lstProposal.OrderBy(p => p.Institution.Name).ThenBy(p => p.StartDate == null ? DateTime.MaxValue : p.StartDate))
            {
                var rowTemplate = _contentService.GetByName("email.weeklynotification.rowTemplate");
                Dictionary<string, string> rowReplacements = new Dictionary<string, string>();
                rowReplacements.Add("PROPOSAL_TITLE", xProposal.Title);

                rowReplacements.Add("PROPOSAL_INSTITUTION", xProposal.Institution.Name);
                rowReplacements.Add("PROPOSAL_STARTDATE", xProposal.StartDate == null ? "-" : xProposal.StartDate.Value.ToString("dd.MM.yyyy"));
                rowReplacements.Add("PROPOSAL_ENDDATE", xProposal.EndDate == null ? "-" : xProposal.EndDate.Value.ToString("dd.MM.yyyy"));
                rowReplacements.Add("PROPOSAL_LIMITDATE", xProposal.LimitDate==null ? "-" : xProposal.LimitDate.Value.ToString("dd.MM.yyyy"));

                proposalsContent += Utils.ProcessReplacements(rowTemplate.Content, rowReplacements);
            }
            replacements.Add("PROPOSALCONTENT", proposalsContent);

            Notification xNotification = this._notificationService.ConstructNotification("email.weeklynotification.title", "email.masterTemplate", "email.weeklynotification.template", "email.defaultFrom", replacements);

            xNotification.To= xUser.Email;
            _dc.Notifications.Add(xNotification);
            _dc.SaveChanges();
        }

        public string LogException(Exception ex)
        {
            string shortMessage = ex.Message;
            Exception exc = ex;
            while (exc.InnerException != null)
            {
                exc = exc.InnerException;
                shortMessage += " : " + exc.Message;
            }

            string message = shortMessage + "\r\n" + exc.StackTrace;
            Logging.LogMessage(message);
            return shortMessage;
        }
       
    }
    public class SubscriptionProcessorSettings
    {
        public string SmtpUserName { get; set; }
    }
}
