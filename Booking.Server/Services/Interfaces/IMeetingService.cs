using Booking.Client.Models;

namespace Booking.Client.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<IEnumerable<Meeting>> GetAllMeetingsAsync();
        Task<Meeting> GetMeetingByIdAsync(string id);
        Task<Meeting> AddMeetingAsync(Meeting meeting);
        Task<Meeting> UpdateMeetingAsync(Meeting meeting);
        Task<Meeting> DeleteMeetingAsync(string id);    
        

    }
}
