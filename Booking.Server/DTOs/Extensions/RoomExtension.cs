using Booking.Client.DTOs.Requests.Rooms;
using Booking.Client.Models;
using Booking.Server.DTOs.Responses;

namespace Booking.Server.DTOs.Extensions
{
    public static class RoomExtension
    {
        public static RoomResponse ToResponseDTO(this Room room)
        {
            return new RoomResponse
            {
                Id = room.Id,
                RoomName = room.Name,
                Capacity = room.Capacity,
                Location = room.Location
            };
        }

        public static Room ToEntityCreateRoom(this CreateRoomRequest roomRequestDTO)
        {
            return new Room
            {
                Name = roomRequestDTO.Name,
                Capacity = roomRequestDTO.Capacity,
                Location = roomRequestDTO.Location
            };
        }

        public static Room ToEntityUpdateRoom(this UpdateRoomRequest roomRequestDTO, Room existingRoom)
        {
            existingRoom.Name = roomRequestDTO.Name;
            existingRoom.Capacity = roomRequestDTO.Capacity;
            existingRoom.Location = roomRequestDTO.Location;
            return existingRoom;
        }
    }
}
