using Ng2Net.TaskRunner.Interfaces;
using Newtonsoft.Json;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Scheduler;
using Ng2Net.Infrastrucure.Logging;
using Ng2Net.Data;
using Ng2Net.Model.Business;

namespace Ng2Net.TaskRunner.ServiceTasks
{
    class ProcessSubscriptions : IServiceTask
    {
        private IRepository<Proposal> _repository;

        public ProcessSubscriptions()
        {
            _repository = new EfRepository<Proposal>(new DatabaseContext());
        }

        public void Run(string settings)
        {
            SubscriptionProcessor proc = new SubscriptionProcessor(_repository, JsonConvert.DeserializeObject<SubscriptionProcessorSettings>(settings));
            int Processed = proc.ProcessQueue();
            if (Processed > 0)
                Logging.LogMessage(string.Format("NotificationProcessor: Processed {0} notifications\r\n", Processed.ToString()));

        }
    }
}
