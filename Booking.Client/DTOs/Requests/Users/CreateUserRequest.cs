namespace Booking.Client.DTOs.Requests.Users
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
    }
}
