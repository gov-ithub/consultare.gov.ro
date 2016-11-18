using Ng2Net.TaskRunner.Interfaces;
using Newtonsoft.Json;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Scheduler;
using Ng2Net.Infrastrucure.Logging;

namespace Ng2Net.TaskRunner.ServiceTasks
{
    public class ProcessNotifications : IServiceTask
    {
        private IRepository<Notification> _repository;

        public ProcessNotifications(IRepository<Notification> repository)
        {
            _repository = repository;
        }

        public void Run(Logging log, string settings)
        {
            NotificationProcessor proc = new NotificationProcessor(_repository, JsonConvert.DeserializeObject<NotificationProcessorSettings>(settings), log);
            int Processed = proc.ProcessQueue();
            if (Processed > 0)
                log.LogMessage(string.Format("NotificationProcessor: Processed {0} notifications\r\n", Processed.ToString()));

        }

    }
}
