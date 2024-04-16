using Booking.Client.Data;
using Booking.Client.Models;
using Booking.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Server.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDBContext _context;

        public MeetingRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingsAsync()
        {
            return await _context.Meetings.ToListAsync();
            //return await _context.Meetings
            //    .Include(m => m.Organizer)  
            //    .Include(r => r.Room)
            //    .Select(m => new Meeting
            //    {
            //        Id = m.Id,
            //        Title = m.Title,
            //        StartTime = m.StartTime,
            //        EndTime = m.EndTime,
            //        Organizer = new User
            //        {
            //            Id = m.Organizer.Id,
            //            Fullname = m.Organizer.Fullname
            //        },
            //        Room = new Room
            //        {
            //            Id = m.Room.Id,
            //            Name = m.Room.Name,
            //            Location = m.Room.Location,
            //        }
                    
            //    })
            //    .ToListAsync();
        }

        public async Task AddMeetingAsync(Meeting meeting)
        {
            await _context.Meetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
        }
        public async Task<Meeting> GetMeetingByIdAsync(string id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task<Meeting> GetRoomByMeetingTitleAsync(string title)
        {
            return await _context.Meetings.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task UpdateMeetingAsync(Meeting meeting)
        {
            var exisingMeeting = await _context.Meetings.FindAsync(meeting.Id);
            if (exisingMeeting != null)
            {
                _context.Meetings.Update(meeting);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMeetingAsync(string id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                await _context.SaveChangesAsync();
            }
        }

    }
}
