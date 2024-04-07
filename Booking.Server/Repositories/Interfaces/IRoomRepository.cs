using Booking.Client.Models;
using Booking.Server.Repositories.Interfaces;

namespace Booking.Client.Repositories.Interfaces
{
    public interface IRoomRepository :IBookingRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(string id);
        Task<Room> GetRoomByRoomNameAsync(string name);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(string id);
    }
}
