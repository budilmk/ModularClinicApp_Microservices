namespace Booking.Domain.Exceptions
{
    [Serializable]
    internal class DoctorNameEmptyException : Exception
    {
        public DoctorNameEmptyException() : base("Doctor name should not be null") { }
    }
}
