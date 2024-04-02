using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;

namespace Booking.Client.DTOs.Mappings
{
    public class MapperConfig
    {
        public User MapCreateUserRequestDTOToEntity(CreateUserRequest userRequestDTO)
        {
            return new User
            {
                Username = userRequestDTO.Username,
                Fullname = userRequestDTO.Fullname,
                Password = userRequestDTO.Password
            };
        }
        public User MapUpdateUserRequestDTOToEntity(UpdateUserRequest userRequestDTO)
        {
            User user = new User
            {                
                Fullname = userRequestDTO.Fullname                
            };
            return user;
        }
        public UserResponse MapEntityToUserResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname
            };
        }        

    }
    public static class UserMapper{
        public static UserResponse ToDTO(this User user) 
        { return new UserResponse 
        { Id = user.Id, Username = user.Username, Fullname = user.Fullname };
        } 
    }

}
