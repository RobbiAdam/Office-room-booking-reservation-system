using Booking.Client.DTOs.Requests.Rooms;
using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;
using Booking.Server.DTOs.Responses;

namespace Booking.Client.DTOs.Mappings
{
    public static class MapperConfig
    {
        public static UserResponse ToResponseDTO(this User user)
        {
            return new UserResponse(user.Id, user.Username, user.Fullname);

        }
        public static User ToEntityCreateUser(this CreateUserRequest userRequestDTO)
        {
            return new User
            {
                Username = userRequestDTO.Username,
                Fullname = userRequestDTO.Fullname,
                Password = userRequestDTO.Password
            };
        }
        public static User ToEntityUpdateUser(this UpdateUserRequest userRequestDTO, User existingUser)
        {
            existingUser.Fullname = userRequestDTO.Fullname;
            return existingUser;
        }
        // Room DTOs response
        public static RoomResponse ToResponseDTO(this Room room)
        {
            return new RoomResponse(room.Id, room.Name, room.Capacity, room.Location);
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
