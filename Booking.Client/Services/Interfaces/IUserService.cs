using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;

namespace Booking.Client.Services.Interfaces
{
    public interface IUserService : IBookingService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(string id);
        Task<UserResponse> AddUserAsync(CreateUserRequest request);
        Task<UserResponse> UpdateUserAsync(string userId, UpdateUserRequest request);
        Task DeleteUserAsync(string id);
    }
}
