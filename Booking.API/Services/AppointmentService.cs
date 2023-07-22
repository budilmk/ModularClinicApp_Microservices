using Booking.Domain.Entities;
using Booking.Infrastructure.Repositories;
using Booking.Domain.Contracts;
using Booking.Shared;
using Microsoft.Extensions.Hosting;

namespace Booking.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepo _appointmentRepository;
        private ISlotRepository _slotRepository;
        public AppointmentService(IAppointmentRepo appointmentRepository, ISlotRepository slotRepository)
        {
            _appointmentRepository = appointmentRepository;
            _slotRepository = slotRepository;
        }

        //Qn 2b to create new appointment 
        public async Task CreateAppointment(string patientName, Guid patientId, Guid slotId)
        {
            var appointment = new Appointment { Id = Guid.NewGuid(), SlotId = slotId, PatientName = patientName, PatientId = patientId, ReservedAt = DateTime.UtcNow, IsCompleted = false };
            await _appointmentRepository.Add(appointment);
        }

        //Qn 3b to cancel appointment based on appointment id
        public async Task CancelAppointment(Guid appointmentId)
        {
            await _appointmentRepository.Cancel(appointmentId);
        }

        //Qn 3b to mark appointment as completed
        public async Task AppointmentIsCompleted(bool status, Guid AppointmentId)
        {
            await _appointmentRepository.AppointmentIsCompleted(status, AppointmentId);

        }

        public Task<List<Appointment>> GetNextAppointment(string doctorName)
        {
            return _appointmentRepository.GetNextAppointment(_slotRepository.GetUpcomingSlotId(doctorName));

        }

        //Qn 3a to get a list of upcoming appointments
        public Task<List<Appointment>> GetNextAppointments(string doctorName)
        {
            return _appointmentRepository.GetNextAppointments(_slotRepository.GetUpcomingSlotIds(doctorName));

        }

    }
}

