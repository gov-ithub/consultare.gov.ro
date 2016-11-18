﻿using Ng2Net.TaskRunner.Interfaces;
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




        //test


        public void Run(string settings)
        {
            NotificationProcessor proc = new NotificationProcessor(_repository, JsonConvert.DeserializeObject<NotificationProcessorSettings>(settings));
            int Processed = proc.ProcessQueue();
            if (Processed > 0)
                Logging.LogMessage(string.Format("NotificationProcessor: Processed {0} notifications\r\n", Processed.ToString()));

        }

    }
}
