namespace Booking.Application.Dtos
{
    public class CreateSlotRequest
    {
        public string? time { get; set; }
        public string? doctorName { get; set; }
        public Guid doctorId { get; set; }
        public decimal cost { get; set; }

    }

    public class DeleteSlotRequest
    {
        public Guid slotid { get; set; }

    }

    public class ListSlotRequest
    {
        public string doctorName { get; set; }

    }

    public class CreateAppointmentRequest
    {
        public string patientName { get; set; }

        public Guid patientId { get; set; }
        public Guid slotId { get; set; }


    }

    public class ListSlotByDoctorRequest
    {
        public string doctorName { get; set; }

    }

    public class GetSlotUpdateRequest
    {
        public bool isReserved { get; set; }
        public Guid slotId { get; set; }


    }

    public class AppointmentUpdateRequest
    {
        public bool isCompleted { get; set; }
        public Guid id { get; set; }

    }

    public class NextAppointmentRequest
    {
        public string doctorName { get; set; }

    }

    public class NextAppointmentsRequest
    {
        public string doctorName { get; set; }

    }

    public class CancelAppointmentRequest
    {
        public Guid appointmentId { get; set; }

    }

    public class GetUpcomingSlotRequest
    {
        public string doctorName { get; set; }

    }

    public class GetUpcomingSlotRequests
    {
        public string doctorName { get; set; }

    }

}


