using Booking.Client.Models;
using Booking.Server.DTOs.Requests.Meetings;
using Booking.Server.DTOs.Responses;

namespace Booking.Client.Services.Interfaces
{
    public interface IMeetingService : IBookingService
    {
        Task<IEnumerable<MeetingResponse>> GetAllMeetingsAsync();
        Task<MeetingResponse> GetMeetingByIdAsync(string id);
        Task<MeetingResponse> AddMeetingAsync(CreateMeetingRequest request);
        Task UpdateMeetingAsync(string meetingId, UpdateMeetingRequest request);
        Task DeleteMeetingAsync(string id);    
        

    }
}
