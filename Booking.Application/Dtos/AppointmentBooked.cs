using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Booking.Application.Dtos;

public class AppointmentBooked : INotification
{
    public AppointmentBooked(Guid id)                                     
    {
        this.SlotId = id;
    }

    public Guid SlotId { get; set; }
}


