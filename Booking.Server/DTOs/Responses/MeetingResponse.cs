﻿namespace Booking.Server.DTOs.Responses
{
    public class MeetingResponse
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public string RoomName { get; init; }
        public string OrganizerFullname { get; init; }        
    }

    
}
