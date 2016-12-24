using Ng2Net.TaskRunner.Interfaces;
using Newtonsoft.Json;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Scheduler;
using Ng2Net.Infrastrucure.Logging;
using Ng2Net.Data;
using Ng2Net.Model.Business;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Services.Scheduler;
using Ng2Net.Model.Admin;
using Ng2Net.Services.Admin;

namespace Ng2Net.TaskRunner.ServiceTasks
{
    class ProcessSubscriptions : IServiceTask
    {
        private IRepository<Proposal> _repository;
        private IRepository<TaskRunnerLog> _taskrunnerLogRepository;
        private INotificationService _notificationService;
        private IHtmlContentService _contentService;

        public ProcessSubscriptions()
        {
            var context = new DatabaseContext();
            _repository = new EfRepository<Proposal>(context);
            _taskrunnerLogRepository = new EfRepository<TaskRunnerLog>(context);
            _notificationService = new NotificationService(new EfRepository<Notification>(context), new EfRepository<HtmlContent>(context));
            _contentService = new HtmlContentService(new EfRepository<HtmlContent>(context));
        }

        public void Run(string settings)
        {
            SubscriptionProcessor proc = new SubscriptionProcessor(_repository, _taskrunnerLogRepository, JsonConvert.DeserializeObject<SubscriptionProcessorSettings>(settings), _notificationService, _contentService);
            int Processed = proc.ProcessQueue();
            if (Processed > 0)
                Logging.LogMessage(string.Format("NotificationProcessor: Processed {0} notifications\r\n", Processed.ToString()));

        }
    }
}
