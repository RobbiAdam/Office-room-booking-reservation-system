using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;
using Mapster;

namespace Booking.Server.DTOs.Extensions
{
    public static class UserExtension
    {
        public static UserResponse ToResponseDTO(this User user)
        {
            var response = user.Adapt<UserResponse>();
            return response;
        }
        public static User ToEntityCreateUser(this CreateUserRequest userRequestDTO)
        {
            var user = userRequestDTO.Adapt<User>();
            return user;
        }
        public static User ToEntityUpdateUser(this UpdateUserRequest userRequestDTO, User existingUser)
        {
            var user = userRequestDTO.Adapt(existingUser);
            return user;
        }
    }
}
