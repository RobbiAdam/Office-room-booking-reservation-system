using Booking.Client.DTOs.Requests.Rooms;
using Booking.Server.DTOs.Responses;

namespace Booking.Client.Services.Interfaces
{
    public interface IRoomService : IBookingService
    {
        Task<IEnumerable<RoomResponse>> GetAllRoomsAsync();
        Task<RoomResponse> GetRoomByIdAsync(string id);
        Task<RoomResponse> GetRoomByRoomNameAsync(string name);
        Task<RoomResponse> AddRoomAsync(CreateRoomRequest request);
        Task<RoomResponse> UpdateRoomAsync(string Id, UpdateRoomRequest request);
        Task DeleteRoomAsync(string id);
    }
}
