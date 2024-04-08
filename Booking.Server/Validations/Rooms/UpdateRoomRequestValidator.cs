using Booking.Client.DTOs.Requests.Rooms;
using FluentValidation;
namespace Booking.Server.Validations.Rooms
{
    public class UpdateRoomRequestValidator : RequestValidator<UpdateRoomRequest>
    {
        public UpdateRoomRequestValidator()
        {
            RuleFor(R => R.Name)
                .NotEmpty().WithMessage("Room name is required")
                .MinimumLength(3).WithMessage("Room name must be at least 3 characters long")
                .MaximumLength(15).WithMessage("Room name must be at most 15 characters long");

            RuleFor(R => R.Capacity)
                .NotEmpty().WithMessage("Room capacity is required")
                .GreaterThan(0).WithMessage("Room capacity must be greater than 0");

            RuleFor(R => R.Location)
                .NotEmpty().WithMessage("Room location is required")
                .MinimumLength(3).WithMessage("Room location must be at least 3 characters long")
                .MaximumLength(15).WithMessage("Room location must be at most 15 characters long");

        }
    }
}
