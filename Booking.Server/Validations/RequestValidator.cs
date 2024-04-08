using FluentValidation;
using FluentValidation.Results;

namespace Booking.Server.Validations
{
    public class RequestValidator<T> : AbstractValidator<T>
    {
        public RequestValidator()
        {
            
        }

        public async Task<ValidationResult> ValidationAsync(T request)
        {
            var context = new ValidationContext<T>(request);
            var result = await ValidateAsync(context);
            return result;
        }
    }
}
