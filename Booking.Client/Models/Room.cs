using Booking.Client.Models.Bases;

namespace Booking.Client.Models
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
