using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services.Interfaces;
using Booking.Server.DTOs.Extensions;
using Booking.Server.DTOs.Requests.Meetings;
using Booking.Server.DTOs.Responses;
using Booking.Server.Repositories.Interfaces;


namespace Booking.Client.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;

        public MeetingService(IMeetingRepository meetingRepository, IUserRepository userRepository, IRoomRepository roomRepository)
        {
            _meetingRepository = meetingRepository;
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }
        public async Task<IEnumerable<MeetingResponse>> GetAllMeetingsAsync()
        {
            var meetings = await _meetingRepository.GetAllMeetingsAsync();
            return meetings.Select(m => m.ToResponseDTO());
        }

        public async Task<MeetingResponse> GetMeetingByIdAsync(string id)
        {
            var meeting = await _meetingRepository.GetMeetingByIdAsync(id);
            return meeting.ToResponseDTO();
        }
        public async Task<MeetingResponse> AddMeetingAsync(CreateMeetingRequest request)
        {
            var organizer = await _userRepository.GetUserByIdAsync(request.OrganizerId);
            if (organizer == null)
            {
                throw new Exception("User not found");
            }

            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
            if (room == null)
            {
                throw new Exception("Room not found");
            }

            var newMeeting = request.ToEntityCreateMeeting(organizer, room);
            

            await _meetingRepository.AddMeetingAsync(newMeeting);
            

            return newMeeting.ToResponseDTO();
        }

        public async Task<MeetingResponse> UpdateMeetingAsync(string meetingId, UpdateMeetingRequest request)
        {
            var exisingMeeting = await _meetingRepository.GetMeetingByIdAsync(meetingId);
            if (exisingMeeting == null)
            {
                throw new Exception("Meeting not found");
            }

            var updatedMeeting = request.ToEntityUpdateMeeting(exisingMeeting);
            await _meetingRepository.UpdateMeetingAsync(updatedMeeting);
            return updatedMeeting.ToResponseDTO();
        }
        public async Task DeleteMeetingAsync(string id)
        {
            var existingMeeting = await _meetingRepository.GetMeetingByIdAsync(id);
            if (existingMeeting == null)
            {
                throw new Exception("Meeting not found");
            }
            await _meetingRepository.DeleteMeetingAsync(id);
        }
    }
}
