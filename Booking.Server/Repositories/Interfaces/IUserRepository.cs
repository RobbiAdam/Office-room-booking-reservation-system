using Booking.Client.Models;
using Booking.Server.Repositories.Interfaces;

namespace Booking.Client.Repositories.Interfaces
{
    public interface IUserRepository :IBookingRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}
