using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ClinicApp.Database;

public class ClinicAppDatabase : DbContext
{
    public DbSet<Slot> Slots { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public ClinicAppDatabase()
    {
    }

    public ClinicAppDatabase(DbContextOptions<ClinicAppDatabase> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("clinic_db");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
public static class DbExtension
{
    public static IServiceCollection AddClinicAppDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClinicAppDatabase>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));
        });
        return services;

    }
}
