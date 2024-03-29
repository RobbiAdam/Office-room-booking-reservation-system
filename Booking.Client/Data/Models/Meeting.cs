using Booking.Client.Data.Models.Bases;

namespace Booking.Client.Data.Models
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoomId { get; set; }
        public string UserId { get; set; }

    }
}
