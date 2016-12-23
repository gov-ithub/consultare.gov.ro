using Ng2Net.TaskRunner.Interfaces;
using Newtonsoft.Json;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Scheduler;
using Ng2Net.Infrastrucure.Logging;
using Ng2Net.Data;
using Ng2Net.Model.Business;

namespace Ng2Net.TaskRunner.ServiceTasks
{
    public class ProcessCrawlers : IServiceTask
    {
        private IRepository<CrawlerConfiguration> _configRepository;
        private IRepository<Proposal> _repository;

        public ProcessCrawlers()
        {
            _configRepository = new EfRepository<CrawlerConfiguration>(new DatabaseContext());
            _repository = new EfRepository<Proposal>(new DatabaseContext());
        }

        public void Run(string settings)
        {
            CrawlerProcessor proc = new CrawlerProcessor(_repository, _configRepository, JsonConvert.DeserializeObject<CrawlerProcessorSettings>(settings));
            int Processed = proc.ProcessQueue();
            if (Processed > 0)
                Logging.LogMessage(string.Format("CrawlerProcessor: Processed {0} notifications\r\n", Processed.ToString()));

        }
    }
}
