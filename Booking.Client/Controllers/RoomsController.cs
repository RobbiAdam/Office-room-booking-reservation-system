using Booking.Client.Data.Models;
using Booking.Client.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roomService.GetAllRoomsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            var newRoom  = await _roomService.AddRoomAsync(room);
            return Ok(newRoom);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room room)
        {
            var updatedRoom = await _roomService.UpdateRoomAsync(room);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedRoom = await _roomService.DeleteRoomAsync(id);
            if (deletedRoom == null)
            {
                return NotFound();
            }
            return Ok(deletedRoom);
        }
    }
}
