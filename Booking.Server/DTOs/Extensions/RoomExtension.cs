using Booking.Client.DTOs.Requests.Rooms;
using Booking.Client.Models;
using Booking.Server.DTOs.Responses;
using Mapster;

namespace Booking.Server.DTOs.Extensions
{
    public static class RoomExtension
    {
        public static RoomResponse ToResponseDTO(this Room room)
        {
            var response = room.Adapt<RoomResponse>();
            return response;
        }

        public static Room ToEntityCreateRoom(this CreateRoomRequest roomRequestDTO)
        {
            var room = roomRequestDTO.Adapt<Room>();
            return room;
        }

        public static Room ToEntityUpdateRoom(this UpdateRoomRequest roomRequestDTO, Room existingRoom)
        {
            var updatedRoom = roomRequestDTO.Adapt(existingRoom);
            return updatedRoom;
        }
    }
}
