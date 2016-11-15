using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ng2Net.Database;
using Ng2Net.Core;
using Ng2Net.TaskRunner.Interfaces;
using Newtonsoft.Json;

namespace Ng2Net.TaskRunner.ServiceTasks
{
    public class ProcessNotifications : IServiceTask
    {
        public void Run(DatabaseContext context, Logging log, string settings)
        {
            NotificationProcessor proc = new NotificationProcessor(context, JsonConvert.DeserializeObject<NotificationProcessorSettings>(settings), log);
            int Processed = proc.ProcessQueue();
            if (Processed > 0)
                log.LogMessage(string.Format("NotificationProcessor: Processed {0} notifications\r\n", Processed.ToString()));

        }

    }
}
