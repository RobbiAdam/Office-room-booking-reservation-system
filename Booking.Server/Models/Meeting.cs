using Booking.Client.Models.Bases;

namespace Booking.Client.Models
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }        
        public string OrganizerId { get; set; }        
        public string RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual User Organizer { get; set; }

        public virtual ICollection<User>? Attendees { get; set; } = new List<User>();
    }
}
