using Booking.Application.Contracts;
using Booking.Shared.Events;
using Convey.MessageBrokers;

namespace Booking.Infrastructure
{
    public class RabbitMQBookingPublisher : IBookPublisher
    {
        private readonly IBusPublisher _busPublisher;
        public RabbitMQBookingPublisher(IBusPublisher busPublisher) 
        {
            _busPublisher = busPublisher;
        }

        public async Task Publish(NewAppointmentBookedEventDto appointmentBooked)
        {
            await _busPublisher.PublishAsync(appointmentBooked);
        }
    }
}