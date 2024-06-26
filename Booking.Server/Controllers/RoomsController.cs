﻿using Booking.Client.DTOs.Requests.Rooms;
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
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoom(string roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);
            if(room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] CreateRoomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newRoom = await _roomService.AddRoomAsync(request);
                return Ok(newRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{roomId}")]
        public async Task<IActionResult> UpdateRoom(string roomId, [FromBody] UpdateRoomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = await _roomService.GetRoomByIdAsync(roomId);
            if (room == null)
            {
                return NotFound();
            }
            try
            {
                await _roomService.UpdateRoomAsync(roomId, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteRoom(string roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);
            if (room == null)
            {
                return NotFound();
            }
            await _roomService.DeleteRoomAsync(roomId);
            return Ok();    
        }
    }
}
