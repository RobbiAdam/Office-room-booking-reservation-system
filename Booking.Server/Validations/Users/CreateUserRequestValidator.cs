using Booking.Client.DTOs.Requests.Users;
using FluentValidation;

namespace Booking.Server.Validations.Users
{
    public class CreateUserRequestValidator : RequestValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters")
                .MaximumLength(20).WithMessage("Username must be at most 20 characters");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(3).WithMessage("Password must be at least 3 characters");

            RuleFor(u => u.Fullname)
                .NotEmpty().WithMessage("Fullname is required")
                .MinimumLength(3).WithMessage("Fullname must be at least 3 characters")
                .MaximumLength(20).WithMessage("Fullname must be at most 20 characters");
        }
    }
}

