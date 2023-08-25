using Convey.MessageBrokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Shared.Events
{
    [Message("bookings", "bookings.newAppointmentBooked", "notifications.newAppointmentBooked")]
    public record NewAppointmentBookedEventDto(Guid slotId, string patientName);

}
