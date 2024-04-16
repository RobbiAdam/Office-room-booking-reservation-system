using Booking.Client.Models;
using Booking.Server.DTOs.Requests.Meetings;
using Booking.Server.DTOs.Responses;

namespace Booking.Server.DTOs.Extensions
{
    public static class MeetingExtension
    {
        public static MeetingResponse ToResponseDTO(this Meeting meeting)
        {
            return new MeetingResponse
            {
                Id = meeting.Id,
                Title = meeting.Title,
                StartTime = meeting.StartTime,
                EndTime = meeting.EndTime,
                RoomName = meeting.Room.Name,
                OrganizerName = meeting.Organizer.Fullname,
            };
        }

        public static Meeting ToEntityCreateMeeting
            (this CreateMeetingRequest meetingRequestDTO, User organizer, Room room)
        {
            return new Meeting
            {
                Title = meetingRequestDTO.Title,
                StartTime = meetingRequestDTO.StartTime,
                EndTime = meetingRequestDTO.EndTime,
                RoomId = meetingRequestDTO.RoomId,
                OrganizerId = meetingRequestDTO.OrganizerId,
                Room = room,
                Organizer = organizer
            };
        }

        public static Meeting ToEntityUpdateMeeting
            (this UpdateMeetingRequest meetingRequestDTO, Meeting existingMeeting)
        {
            existingMeeting.Title = meetingRequestDTO.Title;
            existingMeeting.StartTime = meetingRequestDTO.StartTime;
            existingMeeting.EndTime = meetingRequestDTO.EndTime;
            return existingMeeting;
        }
    }
}
