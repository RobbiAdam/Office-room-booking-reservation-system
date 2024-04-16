using Booking.Client.Models;
using Booking.Server.DTOs.Requests.Meetings;
using Booking.Server.DTOs.Responses;
using Mapster;

namespace Booking.Server.DTOs.Extensions
{
    public static class MeetingExtension
    {
        public static MeetingResponse ToResponseDTO(this Meeting meeting)
        {
            var response = meeting.Adapt<MeetingResponse>();
            return response;
        }

        public static Meeting ToEntityCreateMeeting
            (this CreateMeetingRequest meetingRequestDTO, User organizer, Room room)
        {
            var meeting = meetingRequestDTO.Adapt<Meeting>();
            return meeting;
        }

        public static Meeting ToEntityUpdateMeeting
            (this UpdateMeetingRequest meetingRequestDTO, Meeting existingMeeting)
        {
            var meeting = meetingRequestDTO.Adapt(existingMeeting);
            return meeting;
        }
    }
}
