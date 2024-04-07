using Booking.Client.Models.Bases;

namespace Booking.Client.Models
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User Organizer { get; set; }
        public string UserId { get; set; }
        public Room Room { get; set; }
        public string RoomId { get; set; }

        public IEnumerable<User> Attendees { get; set; } = Enumerable.Empty<User>();



    }
}
