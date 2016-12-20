using Ng2Net.Model.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Infrastructure.Interfaces
{
    public interface INotificationService
    {
        void AddNotification(Notification notification);
        Notification ConstructNotification(string subjectTemplate, string masterTemplate, string template, string fromTemplate, Dictionary<string, string> replacements);
    }
}
