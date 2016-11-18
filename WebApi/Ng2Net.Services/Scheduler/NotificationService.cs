using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Admin;
using Ng2Net.Model.Scheduler;
using System.Linq;


namespace Ng2Net.Services.Scheduler
{
    public class NotificationService
    {
        private IRepository<Notification> _repository;

        public NotificationService(IRepository<Notification> repository)
        {
            _repository = repository;
        }
        
        public void AddNotification(Notification notification)
        {
            _repository.Insert(notification);
            _repository.Save();            
        }
    }
}