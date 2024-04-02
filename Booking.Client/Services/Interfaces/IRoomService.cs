using Booking.Client.Models;

namespace Booking.Client.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(string id);
        Task<Room> GetRoomByRoomNameAsync(string name);
        Task<Room> AddRoomAsync(string name, int capacity, string location);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(string id);
    }
}
