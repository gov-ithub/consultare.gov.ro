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

namespace Ng2Net.TaskRunner
{
    public class NotificationProcessor
    {
        public int SuccessfulNotifications { get; set; }
        public int FailedNotifications { get; set; }
        public int TotalNotifications { get; set; }
        private NotificationProcessorSettings _settings;
        private IRepository<Notification> _repository;

        public NotificationProcessor(IRepository<Notification> repository, NotificationProcessorSettings settings)
        {
            this._repository = repository;
            this._settings = settings;
        }

        public string LogFileName { get; set; }

        public int ProcessQueue()
        {
            //log.LogMessage(" ");
            //log.LogMessage("=================================================");
            //log.LogMessage("Notifier started");
            //log.LogMessage("=================================================");

            //log.LogMessage("Loading items...");
            List<Notification> query = this._repository.GetMany(n => n.Status == "NEW" || (n.Status == "ERROR" && n.Counter < _settings.MaxRetryAttempts)).OrderBy(n => n.Timestamp).Take(_settings.ItemsToProcess).ToList();
            //log.LogMessage("Found " + query.Count() + " items to process. Sending notifications...");
            foreach (Notification note in query)
            {
                TrySendNotification(note.Id);
            }
            //log.LogMessage(this.TotalNotifications + " notifications processed; " + this.SuccessfulNotifications + " successful notifications; " + this.FailedNotifications + " failed notifications");
            return this.SuccessfulNotifications;
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


        private void SendNotification(Notification note)
        {
            note.Counter++;

            if (!string.IsNullOrEmpty(note.To))
            {
                // e-mail notification
                SmtpClient clt = null;
                if (!string.IsNullOrEmpty(_settings.SmtpServer))
                    clt = new SmtpClient(_settings.SmtpServer);
                else
                    clt = new SmtpClient();
                clt.Port = _settings.SmtpPort;
                clt.EnableSsl = _settings.SmtpSsl;

                if (!string.IsNullOrEmpty(_settings.SmtpUserName))
                    clt.Credentials = new NetworkCredential(_settings.SmtpUserName, _settings.SmtpPassword);

                MailMessage msg = note.ToMailMessage();

                if (!string.IsNullOrEmpty(_settings.RecipientOverride))
                {
                    msg.To.Clear();
                    msg.CC.Clear();
                    msg.Bcc.Clear();
                    msg.To.Add(_settings.RecipientOverride);
                }

                clt.Send(msg);
                msg.Dispose();
                if (!string.IsNullOrEmpty(note.Attachments))
                {
                    string[] arrAttachments = note.Attachments.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fileName in arrAttachments)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        if (fi.Exists)
                            fi.Delete();
                    }
                }
            }


            if (note.Status != "SKIPPED")
                note.Status = "SENT";
        }

        public void TrySendNotification(string Id)
        {
            Notification note = this._repository.GetById(Id);
            if (note == null || note.Status == "SENT" || note.Counter >= _settings.MaxRetryAttempts)
                return;

            try
            {
                SendNotification(note);
                this.SuccessfulNotifications++;
            }
            catch (Exception ex)
            {
                note.Error = LogException(ex);
                note.Status = "ERROR";
                this.FailedNotifications++;
            }
            finally { note.DateProcessed = DateTime.Now; this._repository.Save(); this.TotalNotifications++; }

        }
    }


    public class NotificationProcessorSettings
    {
        public int MaxRetryAttempts { get; set; }
        public int ItemsToProcess { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool SmtpSsl { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string RecipientOverride { get; set; }

    }
}
