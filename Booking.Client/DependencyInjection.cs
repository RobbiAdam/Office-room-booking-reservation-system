using Booking.Client.Services;
using Booking.Client.Services.Interfaces;

namespace Booking.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            return services;
        }

    }
}
