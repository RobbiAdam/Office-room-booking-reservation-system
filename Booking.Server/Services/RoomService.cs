using Booking.Client.DTOs.Mappings;
using Booking.Client.DTOs.Requests.Rooms;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services.Interfaces;
using Booking.Server.DTOs.Responses;


namespace Booking.Client.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)        
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomResponse>> GetAllRoomsAsync()
        {
            var rooms =await _roomRepository.GetAllRoomsAsync();
            return rooms.Select(r => r.ToResponseDTO());
        }

        public async Task<RoomResponse> GetRoomByIdAsync(string roomId)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            return room.ToResponseDTO();
        }

        public async Task<RoomResponse> GetRoomByRoomNameAsync(string name)
        {
            var room = await _roomRepository.GetRoomByRoomNameAsync(name);
            return room.ToResponseDTO();
        }
        public async Task<RoomResponse> AddRoomAsync(CreateRoomRequest request)
        {
            var existingRoom = await _roomRepository.GetRoomByRoomNameAsync(request.Name);
            if(existingRoom != null)
            {
                throw new Exception("Room already exists");
            }
            
            var newRoom = request.ToEntityCreateRoom();            

            await _roomRepository.AddRoomAsync(newRoom);
            return newRoom.ToResponseDTO();
        }

        public async Task<RoomResponse> UpdateRoomAsync(string roomId, UpdateRoomRequest request)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            var updatedRoom = request.ToEntityUpdateRoom(room);
            await _roomRepository.UpdateRoomAsync(updatedRoom);
            return updatedRoom.ToResponseDTO();
        }
        public async Task DeleteRoomAsync(string roomId)
        {
            await _roomRepository.DeleteRoomAsync(roomId);
        }
    }
}
