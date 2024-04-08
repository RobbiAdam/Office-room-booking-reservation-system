namespace Booking.Client.DTOs.Requests.Rooms
{
    public record CreateRoomRequest(string Name, int Capacity, string Location);
    
}
