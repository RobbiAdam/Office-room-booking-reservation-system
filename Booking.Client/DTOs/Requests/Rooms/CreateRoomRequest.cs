﻿namespace Booking.Client.DTOs.Requests.Rooms
{
    public class CreateRoomRequest
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}