

using Booking.Shared.Events;

namespace Notification.Module
{
    public interface INotificationService
    {
        public Task CreateNotification(string patientName, Guid slotId);

        public Task Handle(NewAppointmentBookedEventDto notification);
        



    }
}
