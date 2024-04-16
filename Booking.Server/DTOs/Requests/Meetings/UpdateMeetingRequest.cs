using Booking.Client.Models;

namespace Booking.Server.DTOs.Requests.Meetings
{
    public record UpdateMeetingRequest   
        (string Title, DateTime StartTime, DateTime EndTime);
    
}
