

namespace Notification.Module
{
    public interface INotificationService
    {
        public Task CreateNotification(string patientName, Guid slotId);



    }
}
