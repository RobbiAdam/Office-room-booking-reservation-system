using Booking.Client.Models;
using Booking.Server.DTOs;
using Booking.Server.DTOs.Responses;

namespace Booking.Client.DTOs.Responses
{
    public class UserResponse
    {
        public string Id { get; init; }
        public string Username { get; init; }
        public string Fullname { get; init; }
        public IEnumerable<MeetingDTO> OrganizedMeetings { get; init; } 
    }

}
