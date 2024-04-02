namespace Booking.Client.DTOs
{
    public record UserDTO
    {
        public string Id { get; set; }
        public string Username  { get; set; }
        public string Fullname { get; set; }
    }
}
