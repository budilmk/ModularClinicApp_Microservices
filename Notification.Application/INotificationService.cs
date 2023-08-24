

using Booking.Shared.Events;

namespace Notification.Application
{
    public interface INotificationService
    {
        public Task CreateNotification(string patientName, Guid slotId);

        public Task Handle(NewAppointmentBookedEventDto notification);




    }
}
