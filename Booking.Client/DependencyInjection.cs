using Booking.Client.Repositories;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services;
using Booking.Client.Services.Interfaces;
using Booking.Client.Utils;
using Booking.Client.Utils.Mappings;
using Mapster;

namespace Booking.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            MappingConfig.RegisterMaps();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IMeetingService, MeetingService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            //services.AddScoped<IMeetingRepository, MeetingRepository>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }

    }
}
