using Booking.Client.Models;
using Booking.Client.Services.Interfaces;
using Booking.Server.DTOs.Requests.Meetings;
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

        [HttpPost]
        public async Task<IActionResult> AddMeeting([FromBody] CreateMeetingRequest meeting)
        {
            try
            {
                var newMeeting = await _meetingService.AddMeetingAsync(meeting);
                return CreatedAtAction(nameof(GetMeetingById), new { id = newMeeting.Id }, newMeeting);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeeting(string id, [FromBody] UpdateMeetingRequest meeting)
        {
            try
            {
                await _meetingService.UpdateMeetingAsync(id, meeting);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(string id)
        {
            try
            {
                await _meetingService.DeleteMeetingAsync(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
