using Booking.Client.Models.Bases;

namespace Booking.Client.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        public virtual IEnumerable<Meeting>? OrganizedMeetings { get; set; } = new List<Meeting>();
        public virtual IEnumerable<Meeting>? AttendedMeetings{ get; set; } = new List<Meeting>();
    }
}
