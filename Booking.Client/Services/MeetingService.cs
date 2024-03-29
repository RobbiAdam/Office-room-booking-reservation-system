using Booking.Client.Data;
using Booking.Client.Data.Models;
using Booking.Client.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ApplicationDBContext _context;

        public MeetingService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Meeting> AddMeetingAsync(Meeting meeting)
        {
            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();
            return meeting;
        }

        public async Task<Meeting> DeleteMeetingAsync(string id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                await _context.SaveChangesAsync();
            }
            return meeting;
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingsAsync()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<Meeting> GetMeetingByIdAsync(string id)
        {
            return await _context.Meetings.FindAsync(id);
        }
        public async Task<Meeting> UpdateMeetingAsync(Meeting meeting)
        {
            var existingMeeting = await _context.Meetings.FindAsync(meeting.Id);
            if (existingMeeting != null)
            {
                _context.Entry(existingMeeting).CurrentValues.SetValues(meeting);
                await _context.SaveChangesAsync();
            }
            return meeting;
        }
    }
}
