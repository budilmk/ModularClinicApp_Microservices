using Booking.Domain.Entities;
using SlotManagement.Repositories;


namespace SlotManagement.Services
{
    public class SlotService : ISlotService
    {
        private ISlotRepository _slotRepository;
        public SlotService(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        //Question 1a,b
        public async Task CreateSlot(string time, string doctorName, Guid doctorId, decimal cost)
        {
            if (string.IsNullOrEmpty(doctorName))
            {
                //throw new DoctorNameEmptyException();
            }

            var dateTime = DateTime.Parse(time);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc); //convert format to UTC as required by db
            var slot = new Slot { Id = Guid.NewGuid(), Time = dateTime, DoctorName = doctorName, DoctorId = doctorId, Cost = cost, IsReserved = false };
            await _slotRepository.Add(slot);

        }

        public async Task DeleteSlot(Guid id)
        {
            await _slotRepository.Delete(id);

        }

        //Question 1a
        public async Task<List<Slot>> GetSlotsByDoctor(string? doctorName)
        {
            return await _slotRepository.ListSlotByDoctor(doctorName);

        }

        public async Task<List<Slot>> GetAllSlots()
        {
            return await _slotRepository.ListAllSlots();
        }

        public async Task<List<Slot>> GetAvailableSlots()
        {
            return await _slotRepository.ListAvailableSlots();
        }

        public async Task UpdateSlotReservation(bool isReserved, Guid slotId)
        {
            await _slotRepository.UpdateSlotReservation(isReserved, slotId);

        }

        public Guid GetUpcomingSlotId(string doctorName)
        {
            return _slotRepository.GetUpcomingSlotId(doctorName);

        }

        public string GetDoctorNameBySlotId(Guid slotid)
        {
            return _slotRepository.GetDoctorNameBySlotId(slotid);

        }

        public DateTime GetAppointmentTimeBySlotId(Guid slotid)
        {
            return _slotRepository.GetAppointmentTimeBySlotId(slotid);

        }

        public List<Guid> GetUpcomingSlotIds(string doctorName)
        {
            return _slotRepository.GetUpcomingSlotIds(doctorName);

        }

    }
}



