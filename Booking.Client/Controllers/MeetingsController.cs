using Booking.Client.Data.Models;
using Booking.Client.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMeeting(Meeting meeting)
        {
            try
            {
                var newMeeting = await _meetingService.AddMeetingAsync(meeting);
                return Ok(newMeeting);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetMeetings()
        {
            var meetings = await _meetingService.GetAllMeetingsAsync();
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetingById(string id)
        {
            var meeting = await _meetingService.GetMeetingByIdAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting);
        }

    }
}
