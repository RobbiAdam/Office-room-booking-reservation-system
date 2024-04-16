namespace Booking.Server.DTOs.Responses
{
    public class RoomResponse
    {
        public string Id { get; init; }
        public string RoomName { get; init; }
        public int Capacity { get; init; }
        public string Location { get; init; }
    }

}
