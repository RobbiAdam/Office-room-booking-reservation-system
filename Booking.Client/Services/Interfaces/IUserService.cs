using Booking.Client.Models;

namespace Booking.Client.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> AddUserAsync(string username, string fullname, string password);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}
