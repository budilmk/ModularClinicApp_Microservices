using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Application.Dtos;
using Booking.Shared.Events;

namespace Booking.Application.Contracts;

public interface IBookPublisher
{ 
    Task Publish(NewAppointmentBookedEventDto appointmentBooked);
    
}
