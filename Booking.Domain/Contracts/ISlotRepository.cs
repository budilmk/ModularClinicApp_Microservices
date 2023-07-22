using Booking.Domain.Entities;

namespace Booking.Domain.Contracts
{
    public interface ISlotRepository
    {
        public bool SlotIdIsExist(Guid id);
        public Task Add(Slot slot);
        public Task Delete(Guid slotId);
        public Task<List<Slot>> ListSlotByDoctor(string doctorName);
        public Task<List<Slot>> ListAllSlots();
        public Task<List<Slot>> ListAvailableSlots();
        public Guid GetUpcomingSlotId(string doctorName);
        public string GetDoctorNameBySlotId(Guid slotId);
        public DateTime GetAppointmentTimeBySlotId(Guid slotId);
        public List<Guid> GetUpcomingSlotIds(string doctorName);
        public Task UpdateSlotReservation(bool isReserved, Guid slotId);

    }
}
