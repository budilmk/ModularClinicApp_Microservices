using Microsoft.EntityFrameworkCore;
using Booking.Domain.Contracts;
using Booking.Domain.Entities;
using Booking.Infrastructure.Database;

namespace Booking.Infrastructure.Repositories;

public class AppointmentRepo : IAppointmentRepo
{
    private ClinicDatabase _db;

    public AppointmentRepo(ClinicDatabase db)
    {
        _db = db;
    }

    public async Task Add(Appointment appointment)
    {
        _db.Appointments.Add(appointment);
        await _db.SaveChangesAsync();
    }

    public async Task Cancel(Guid Id)
    {
        var itemToRemove = _db.Appointments.Single(x => x.Id == Id);
        _db.Appointments.Remove(itemToRemove);
        await _db.SaveChangesAsync();
    }

    public async Task AppointmentIsCompleted(bool status, Guid id)
    {
        var result = new Appointment { Id = id, IsCompleted = status };
        _db.Appointments.Attach(result).Property(x => x.IsCompleted).IsModified = true;
        await _db.SaveChangesAsync();

    }

    public async Task<List<Appointment>> GetNextAppointment(Guid Id)
    {
        return _db.Appointments.Where(x => x.SlotId == Id).ToList();
    }

    public async Task<List<Appointment>> GetNextAppointments(List<Guid> Id)
    {
        List<Appointment> result = new List<Appointment>();
        var y = 0;
        foreach (var x in Id)
        {
            result.Add(_db.Appointments.Where(x => x.SlotId == Id[y]).Single());
            y++;
        }
        return result;


    }
}
