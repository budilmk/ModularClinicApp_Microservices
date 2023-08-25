using Booking.Application.Dtos;
using Microsoft.Extensions.Logging;
using Booking.Application.Contracts;
using Booking.Shared.Events;
using Booking.Shared;

namespace Booking.Application.UseCases
{
    public class BookAppointment
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<BookAppointment> _logger;
        private readonly IBookPublisher _bookPublisher;

        public BookAppointment(ILogger<BookAppointment> logger, IBookPublisher bookPublisher, IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            _bookPublisher = bookPublisher;
            _logger = logger;
        }

        public async Task<Guid> Execute(CreateAppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.patientName, request.patientId, request.slotId); //create new appointment
            await _bookPublisher.Publish(new NewAppointmentBookedEventDto(request.slotId, request.patientName));

            return request.slotId;
        }

       

    }
}
