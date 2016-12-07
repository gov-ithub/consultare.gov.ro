using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Scheduler;


namespace Ng2Net.Services.Scheduler
{
    public class NotificationService: INotificationService
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