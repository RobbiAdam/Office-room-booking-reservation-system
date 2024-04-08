using Booking.Client.DTOs.Mappings;
using Booking.Client.DTOs.Requests.Rooms;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services.Interfaces;
using Booking.Server.DTOs.Responses;
using Booking.Server.Validations.Rooms;


namespace Booking.Client.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly CreateRoomRequestValidator _createRoomRequestValidator;
        private readonly UpdateRoomRequestValidator _updateRoomRequestValidator;

        public RoomService(IRoomRepository roomRepository, 
            CreateRoomRequestValidator createRoomRequestValidator, 
            UpdateRoomRequestValidator updateRoomRequestValidator)
        {
            _roomRepository = roomRepository;
            _createRoomRequestValidator = createRoomRequestValidator;
            _updateRoomRequestValidator = updateRoomRequestValidator;
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
            var validationResult = await _createRoomRequestValidator.ValidationAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException
                    (validationResult.Errors.Select(e => e.ErrorMessage)
                    .Aggregate((x, y) => $"{x}{Environment.NewLine}{y}"));
            }

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
            var validationResult = await _updateRoomRequestValidator.ValidationAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException
                    (validationResult.Errors.Select(e => e.ErrorMessage)
                    .Aggregate((x, y) => $"{x}{Environment.NewLine}{y}"));
            }

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
