using Booking.Client.Data.Models.Bases;

namespace Booking.Client.Data.Models
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
