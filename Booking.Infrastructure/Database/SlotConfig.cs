using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database;

public class SlotConfig : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.ToTable("Slots");
        builder.HasKey(x => x.DoctorName);
        builder.HasKey(x => x.Id);
        //throw new NotImplementedException();
    }
}
