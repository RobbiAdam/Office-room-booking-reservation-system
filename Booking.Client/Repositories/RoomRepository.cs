using Booking.Client.Data;
using Booking.Client.Data.Models;
using Booking.Client.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDBContext _context;

        public RoomRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(string id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<Room> GetRoomByRoomNameAsync(string name)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(string id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
