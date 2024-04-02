using Booking.Client.Data;

using Booking.Client.Requests.Users;
using Booking.Client.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newUser = await _userService.AddUserAsync(request.Username, request.FullName, request.Password);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUserRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.GetUserByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }
            user.FullName = request.FullName;
            try
            {
                await _userService.UpdateUserAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }    
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
           var user = await _userService.GetUserByIdAsync(userId);
           if(user == null)
           {
                return NotFound();
           }
           await _userService.DeleteUserAsync(userId);
           return Ok();
        }

    }
}