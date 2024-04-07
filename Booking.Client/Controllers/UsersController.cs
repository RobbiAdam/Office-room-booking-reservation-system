using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<ActionResult<UserResponse>> GetUser(string userId)
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
                var newUser = await _userService.AddUserAsync(request);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            try
            {       
                await _userService.UpdateUserAsync(userId, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error when updating user " + ex.Message);
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