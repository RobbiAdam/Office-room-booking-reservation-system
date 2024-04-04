using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;

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
            //User user = new User
            //{                
            //    Fullname = userRequestDTO.Fullname                
            //};
            existingUser.Fullname = userRequestDTO.Fullname;
            return existingUser;
        }
    }
}
