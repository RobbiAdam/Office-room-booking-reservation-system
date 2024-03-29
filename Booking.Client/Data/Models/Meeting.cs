using Booking.Client.Data.Models.Bases;

namespace Booking.Client.Data.Models
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }

        public Room Room { get; set; }
        public User User { get; set; }

        

    }
}
