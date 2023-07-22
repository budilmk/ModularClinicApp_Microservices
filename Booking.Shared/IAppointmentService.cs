using Booking.Domain.Entities;

namespace Booking.Shared
{
    public interface IAppointmentService
    {
        public Task CreateAppointment(string patientName, Guid patientId, Guid slotId);
        public Task CancelAppointment(Guid appointmentId);
        public Task AppointmentIsCompleted(bool status, Guid ApplicationId);
        public Task<List<Appointment>> GetNextAppointment(string doctorName);
        public Task<List<Appointment>> GetNextAppointments(string doctorName);

    }
}
