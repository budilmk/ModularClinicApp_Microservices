using Booking.Domain.Entities;

namespace Booking.Shared
{
    public interface ISlotService
    {
        public Task CreateSlot(string time, string doctorName, Guid doctorId, decimal cost);
        public Task DeleteSlot(Guid id);

        public Task<List<Slot>> GetSlotsByDoctor(string doctorName);
        public Task<List<Slot>> GetAllSlots();
        public Task<List<Slot>> GetAvailableSlots();
        public Guid GetUpcomingSlotId(string doctorName);
        public string GetDoctorNameBySlotId(Guid slotid);
        public DateTime GetAppointmentTimeBySlotId(Guid slotid);
        public List<Guid> GetUpcomingSlotIds(string doctorName);
        public Task UpdateSlotReservation(bool isReserved, Guid slotId);



    }
}
