using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure.Database
{
    public class ClinicDatabase : DbContext
    {
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public ClinicDatabase(DbContextOptions<ClinicDatabase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("clinic_db");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
    public static class Extensions
    {
        public static IServiceCollection AddClinicAppDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicDatabase>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
            });
            return services;

        }
    }



}


