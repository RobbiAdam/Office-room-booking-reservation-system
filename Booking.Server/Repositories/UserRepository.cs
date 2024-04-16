using Booking.Client.Data;
using Booking.Client.Models;
using Booking.Client.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            //return await _context.Users
            //    .Include(u => u.OrganizedMeetings)
            //        .ThenInclude(m => m.Room)
            //        .Select(u => new User
            //        {
            //            Id = u.Id,
            //            Username = u.Username,
            //            Fullname = u.Fullname,
            //            OrganizedMeetings = u.OrganizedMeetings.Select(m => new Meeting
            //            {
            //                Id = m.Id,
            //                Title = m.Title,
            //                StartTime = m.StartTime,
            //                EndTime = m.EndTime,
            //                RoomId = m.RoomId,
            //                OrganizerId = m.OrganizerId,
            //                Room = new Room
            //                {
            //                    Id = m.Room.Id,
            //                    Name = m.Room.Name,
            //                    Capacity = m.Room.Capacity,
            //                    Location = m.Room.Location
            //                },
            //                Organizer = new User
            //                {
            //                    Id = m.Organizer.Id,
            //                    Username = m.Organizer.Username,
            //                    Fullname = m.Organizer.Fullname
            //                }
            //            }).ToList()
            //        }).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
