using Booking.Client.Models;

namespace Booking.Server.DTOs.Requests.Meetings
{
    public record CreateMeetingRequest
        (string Title, DateTime StartTime, DateTime EndTime, 
        string RoomId, string OrganizerId);

}
