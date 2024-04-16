namespace Booking.Server.DTOs.Responses
{
    public class UserMeetingResponse
    {
        public string Title { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public string RoomName { get; init; }
    }
}
