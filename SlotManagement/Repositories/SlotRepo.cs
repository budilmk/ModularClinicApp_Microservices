using Booking.Domain.Entities;
using Booking.Infrastructure.Database;


namespace SlotManagement.Repositories;

public class SlotRepo : ISlotRepository
{
    private ClinicAppDatabase _db;

    public SlotRepo(ClinicAppDatabase db)
    {
        _db = db;
    }

    public bool SlotIdIsExist(Guid slotId)
    {
        return _db.Slots.Any(x => x.Equals(slotId));
    }

    //add slot
    public async Task Add(Slot slot)
    {
        _db.Slots.Add(slot);
        await _db.SaveChangesAsync();
    }

    //remove slot
    public async Task Delete(Guid SlotId)
    {
        var itemToRemove = _db.Slots.SingleOrDefault(x => x.Id == SlotId);
        _db.Slots.Remove(itemToRemove);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Slot>> ListSlotByDoctor(string doctorName)
    {
        return _db.Slots.Where(x => x.DoctorName == doctorName).ToList();

    }

    public async Task<List<Slot>> ListAllSlots()
    {
        return _db.Slots.ToList();

    }

    //check IsReserved field, return only true
    public async Task<List<Slot>> ListAvailableSlots()
    {
        return _db.Slots.Where(x => x.IsReserved == false).ToList();

    }
    public async Task UpdateSlotReservation(bool isReserved, Guid slotId)
    {
        var result = new Slot { Id = slotId, IsReserved = isReserved };
        _db.Slots.Attach(result).Property(x => x.IsReserved).IsModified = true;
        await _db.SaveChangesAsync();

    }

    //return single Id
    public Guid GetUpcomingSlotId(string doctorName)
    {
        var result = _db.Slots.Where(x => x.IsReserved == true).Where(x => x.DoctorName == doctorName).Where(x => x.Time > DateTime.UtcNow).Single();
        Console.WriteLine(result.Id);
        return result.Id;

    }

    public string GetDoctorNameBySlotId(Guid slotid)
    {
        var result = _db.Slots.Where(x => x.Id == slotid).Single();
        Console.WriteLine(result.DoctorName);
        return result.DoctorName;

    }

    public DateTime GetAppointmentTimeBySlotId(Guid slotid)
    {
        var result = _db.Slots.Where(x => x.Id == slotid).Single();
        Console.WriteLine(result.Time);
        return result.Time;
    }

    //return multiple Ids
    public List<Guid> GetUpcomingSlotIds(string doctorName)
    {
        List<Guid> slotIds = new List<Guid>();
        var slot = _db.Slots.Where(x => x.IsReserved == true).Where(x => x.DoctorName == doctorName).Where(x => x.Time > DateTime.UtcNow).ToList();
        foreach (var slotId in slot)
        {
            slotIds.Add(slotId.Id);
        }

        return slotIds;

    }


}



