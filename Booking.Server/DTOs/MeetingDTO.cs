namespace Booking.Server.DTOs
{
    public class MeetingDTO
    {
        public string MeetingTitle { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public string RoomName { get; init; }
    }
}
