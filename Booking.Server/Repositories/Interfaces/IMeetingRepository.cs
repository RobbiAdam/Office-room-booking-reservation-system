using Booking.Client.Models;

namespace Booking.Server.Repositories.Interfaces
{
    public interface IMeetingRepository : IBookingRepository
    {
        Task<IEnumerable<Meeting>> GetAllMeetingsAsync();
        Task<Meeting> GetMeetingByIdAsync(string id);
        Task<Meeting> GetRoomByMeetingTitleAsync(string title);
        Task AddMeetingAsync(Meeting room);
        Task UpdateMeetingAsync(Meeting room);
        Task DeleteMeetingAsync(string id);
    }
}
