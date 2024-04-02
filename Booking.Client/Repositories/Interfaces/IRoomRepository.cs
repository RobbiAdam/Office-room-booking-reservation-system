using Booking.Client.Models;

namespace Booking.Client.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(string id);
        Task<Room> GetRoomByRoomNameAsync(string name);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(string id);
    }
}
