using Booking.Client.Data;
using Booking.Client.DTOs;
using Booking.Client.DTOs.Mappings;
using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Models;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services.Interfaces;
using Booking.Client.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        //private readonly MapperConfig _mapper;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            
        }
        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(user => user.ToResponseDTO());
        }

        public async Task<UserResponse> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            
            return user?.ToResponseDTO();
        }

        public async Task<UserResponse> AddUserAsync(CreateUserRequest request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user != null)
            {
                throw new Exception("Username already exists");
            }

            var userId = Guid.NewGuid().ToString();
            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var newUser = request.ToEntityCreateUser();
            newUser.Id = userId;
            newUser.Password = passwordHash;

            await _userRepository.AddUserAsync(newUser);
            return newUser.ToResponseDTO();
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }       

        public async Task<UserResponse> UpdateUserAsync(string userId, UpdateUserRequest request)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            var updatedUser = request.ToEntityUpdateUser(user);            

            await _userRepository.UpdateUserAsync(updatedUser);
            return updatedUser.ToResponseDTO();
        }
    }
}
