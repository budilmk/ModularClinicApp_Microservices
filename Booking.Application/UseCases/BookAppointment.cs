using Booking.Application.Dtos;
using Microsoft.Extensions.Logging;
using Booking.Shared;
using Microsoft.AspNetCore.Mvc;
using Booking.Application.Contracts;
using System.Reflection.Metadata.Ecma335;
using Booking.Shared.Events;

namespace Booking.Application.UseCases
{
    public class BookAppointment
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<BookAppointment> _logger;
        private readonly IBookPublisher _bookPublisher;

        public BookAppointment(IAppointmentService appointmentService, ILogger<BookAppointment> logger, IBookPublisher bookPublisher)
        {
            _appointmentService = appointmentService;
            _bookPublisher = bookPublisher;
            _logger = logger;
        }

        public async Task<Guid> Execute(CreateAppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.patientName, request.patientId, request.slotId); //create new appointment
            await _bookPublisher.Publish(new NewAppointmentBookedEventDto(request.slotId));

            return request.slotId;
        }

       

    }
}
