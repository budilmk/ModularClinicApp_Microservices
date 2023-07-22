using System.ComponentModel.DataAnnotations;

namespace Booking.Domain.Entities
{
    public class Appointment
    {
        [Key] public Guid Id { get; set; }
        [Required] public Guid SlotId { get; set; }
        [Required] public Guid PatientId { get; set; }
        [Required] public string? PatientName { get; set; }
        public DateTime ReservedAt { get; set; }
        public bool IsCompleted { get; set; }

    }
}

