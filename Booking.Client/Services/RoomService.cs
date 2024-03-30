using Booking.Client.Data;
using Booking.Client.Data.Models;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)        
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }

        public async Task<Room> GetRoomByIdAsync(string id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task<Room> GetRoomByRoomNameAsync(string name)
        {
            return await _roomRepository.GetRoomByRoomNameAsync(name);
        }
        public async Task<Room> AddRoomAsync(string name, int capacity, string location)
        {
            var existingRoom = await _roomRepository.GetRoomByRoomNameAsync(name);
            if(existingRoom != null)
            {
                throw new Exception("Room already exists");
            }
            var roomId = Guid.NewGuid().ToString();
            var newRoom = new Room
            {
                Id = roomId,
                Name = name,
                Capacity = capacity,
                Location = location
            };

            await _roomRepository.AddRoomAsync(newRoom);
            return newRoom;
        }

        public async Task UpdateRoomAsync(Room room)
        {
            await _roomRepository.UpdateRoomAsync(room);
        }
        public async Task DeleteRoomAsync(string id)
        {
            await _roomRepository.DeleteRoomAsync(id);
        }
    }
}
