using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;

namespace Booking.Server.DTOs.Extensions
{
    public static class UserExtension
    {
        public static UserResponse ToResponseDTO(this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname,
                OrganizedMeetings = user.OrganizedMeetings.Select(m => new MeetingDTO
                {
                    MeetingTitle = m.Title,
                    StartTime = m.StartTime,
                    EndTime = m.EndTime,
                    RoomName = m.Room.Name
                })
            };
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
    }
}
