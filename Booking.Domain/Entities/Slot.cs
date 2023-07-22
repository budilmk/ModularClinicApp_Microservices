using System.ComponentModel.DataAnnotations;


namespace Booking.Domain.Entities
{
    public class Slot
    {
        [Key] public Guid Id { get; set; }
        [Required] public DateTime Time { get; set; }
        [Required] public Guid DoctorId { get; set; }
        [Required][MinLength(2)] public string? DoctorName { get; set; }
        public bool? IsReserved { get; set; }
        [Required][Range(0, 1000000000)] public decimal? Cost { get; set; }

    }
}
