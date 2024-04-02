using Booking.Client.Models.Bases;

namespace Booking.Client.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
