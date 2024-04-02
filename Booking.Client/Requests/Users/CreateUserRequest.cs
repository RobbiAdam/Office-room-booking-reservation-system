namespace Booking.Client.Requests.Users
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
