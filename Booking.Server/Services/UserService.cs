using Booking.Client.DTOs.Requests.Users;
using Booking.Client.DTOs.Responses;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services.Interfaces;
using Booking.Client.Utils;
using Booking.Server.DTOs.Extensions;
using Booking.Server.Validations.Users;


namespace Booking.Client.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly CreateUserRequestValidator _createvalidator;
        private readonly UpdateUserRequestValidator _updateValidator;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher,
            CreateUserRequestValidator createvalidator, UpdateUserRequestValidator updateValidator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _createvalidator = createvalidator;
            _updateValidator = updateValidator;
        }
        public async Task<UserResponse> AddUserAsync(CreateUserRequest request)
        {
            var validationResult = await _createvalidator.ValidationAsync(request);
            if (!validationResult.IsValid)
                throw new ArgumentException
                    (validationResult.Errors.Select(e => e.ErrorMessage)
                    .Aggregate((x, y) => $"{x}{Environment.NewLine}{y}"));

            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user != null)
            {
                throw new Exception("Username already exists");
            }

            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var newUser = request.ToEntityCreateUser();
            newUser.Password = passwordHash;

            await _userRepository.AddUserAsync(newUser);
            return newUser.ToResponseDTO();
        }


        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(user => user.ToResponseDTO());
        }

        public async Task<UserResponse> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }            
            return user.ToResponseDTO();
        }

        public async Task<UserResponse> UpdateUserAsync(string userId, UpdateUserRequest request)
        {
            var validationResult = await _updateValidator.ValidationAsync(request);

            if (!validationResult.IsValid)
                throw new ArgumentException
                    (validationResult.Errors.Select(e => e.ErrorMessage)
                    .Aggregate((x, y) => $"{x}{Environment.NewLine}{y}"));

            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var updatedUser = request.ToEntityUpdateUser(user);

            await _userRepository.UpdateUserAsync(updatedUser);
            return updatedUser.ToResponseDTO();
        }
        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }       

    }
}
