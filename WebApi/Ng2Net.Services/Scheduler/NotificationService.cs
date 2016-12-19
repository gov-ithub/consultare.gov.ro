using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Admin;
using Ng2Net.Model.Scheduler;
using System.Collections.Generic;

namespace Ng2Net.Services.Scheduler
{
    public class NotificationService: INotificationService
    {
        private IRepository<Notification> _repository;
        private IRepository<HtmlContent> _contentRepo;

        public NotificationService(IRepository<Notification> repository, IRepository<HtmlContent> contentRepo)
        {
            _repository = repository;
            _contentRepo = contentRepo;
        }
        
        public void AddNotification(Notification notification)
        {
            _repository.Insert(notification);
            _repository.Save();
        }

        public Notification ConstructNotification(string subjectTemplate, string masterTemplate, string template, string fromTemplate, Dictionary<string, string> replacements) {
            HtmlContent masterTemplateContent = _contentRepo.Get(c => c.Name == masterTemplate);
            HtmlContent templateContent = _contentRepo.Get(c => c.Name == template);
            HtmlContent subjectContent = _contentRepo.Get(c => c.Name == subjectTemplate);
            HtmlContent fromContent = _contentRepo.Get(c => c.Name == fromTemplate);
            HtmlContent rootUrlContent = _contentRepo.Get(c => c.Name == "email.defaultUrl");
            if (rootUrlContent != null && !replacements.ContainsKey("ROOT_URL"))
                replacements.Add("ROOT_URL", rootUrlContent.Content);
            string templateResult = Utils.ProcessReplacements(templateContent.Content, replacements);
            var masterReplacements = new Dictionary<string, string>();
            masterReplacements.Add("CONTENT", templateResult);
            masterReplacements.Add("ROOT_URL", rootUrlContent.Content);

            templateResult = Utils.ProcessReplacements(masterTemplateContent.Content, masterReplacements);
            return new Notification() { Body = templateResult, Subject=Utils.ProcessReplacements(subjectContent.Content, replacements), From = fromContent.Content };
        }
    }
}