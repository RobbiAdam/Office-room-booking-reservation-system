using Booking.Client.Data;
using Booking.Client.Data.Models;
using Booking.Client.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDBContext _context;

        public RoomService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Room> AddRoomAsync(Room room)
        {
            _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> DeleteRoomAsync(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
            return room;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(Guid id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            var existingRoom = await _context.Rooms.FindAsync(room.Id);
            if(existingRoom != null)
            {
                _context.Entry(existingRoom).CurrentValues.SetValues(room);
                await _context.SaveChangesAsync();
            }
            return room;
        }
    }
}
