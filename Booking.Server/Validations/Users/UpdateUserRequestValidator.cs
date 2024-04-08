using Booking.Client.DTOs.Requests.Users;
using FluentValidation;

namespace Booking.Server.Validations.Users
{
    public class UpdateUserRequestValidator : RequestValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(u => u.Fullname)
                .NotEmpty().WithMessage("Fullname is required")
                .MinimumLength(3).WithMessage("Fullname must be at least 3 characters")
                .MaximumLength(20).WithMessage("Fullname must be at most 20 characters"); 
        }
    }
}
