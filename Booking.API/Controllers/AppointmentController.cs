using Booking.API.Services;
using Booking.Shared;
using Microsoft.AspNetCore.Mvc;
using Booking.Application.Dtos;
using SlotManagement.Services;
using Microsoft.Extensions.Logging;
using Notification.Module;
using Booking.Application.UseCases;

namespace Booking.API.Controllers
{
    [Route("/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ISlotService _slotService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<AppointmentController> _logger;
        private readonly BookAppointment _bookAppointment;

        public AppointmentController(IAppointmentService appointmentService, ISlotService slotService, INotificationService notificationService, ILogger<AppointmentController> logger, BookAppointment bookAppointment)
        {
            _appointmentService = appointmentService;
            _slotService = slotService;
            _logger = logger;
            _notificationService = notificationService;
            _bookAppointment = bookAppointment;
        }

        //Question 2b To book an appointment and update slot reservation status
        [HttpPost("/appointments/book")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.patientName, request.patientId, request.slotId); //create new appointment
            await _slotService.UpdateSlotReservation(true, request.slotId); //update slot status to true
            await _notificationService.CreateNotification(request.patientName, request.slotId);


            return Ok("Appointment Created...");
        }

        [HttpPost("/appointments/book1")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentRequest request)
        {
            var slotId = await _bookAppointment.Execute(request);

            return Ok("Appointment Created...");
        }

        //Question 3a TO get multiple next appointments, based on the doctor and available slots
        [HttpPost("/appointments/nextappointments")]
        public async Task<IActionResult> NextAppointments([FromBody] NextAppointmentsRequest request)
        {
            return Ok(await _appointmentService.GetNextAppointments(request.doctorName));
        }

        //Question 3b TO mark an appointment as completed
        [HttpPost("/appointments/iscomplete")]
        public async Task<IActionResult> AppointmentUpdate([FromBody] AppointmentUpdateRequest request)
        {
            await _appointmentService.AppointmentIsCompleted(request.isCompleted, request.id); //Mark appointment as completed
            return Ok("Appointment Updated...");
        }

        //Question 3b To cancel appointment and delete
        [HttpPost("/appointments/cancel")]
        public async Task<IActionResult> CancelAppointment([FromBody] CancelAppointmentRequest request)
        {
            await _appointmentService.CancelAppointment(request.appointmentId);
            return Ok("Appointment cancelled...");

        }

    }
}



