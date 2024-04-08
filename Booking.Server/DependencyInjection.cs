using Booking.Client.Services.Interfaces;
using Booking.Client.Utils;
using Booking.Server.Repositories.Interfaces;
using Booking.Server.Validations.Rooms;
using Booking.Server.Validations.Users;


namespace Booking.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(s => s
            .FromAssemblyOf<IBookingService>()
            .AddClasses(c => c.AssignableTo<IBookingService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

            services.Scan(s => s
            .FromAssemblyOf<IBookingRepository>()
            .AddClasses(c => c.AssignableTo<IBookingRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );
            services.AddTransient<CreateUserRequestValidator>();
            services.AddTransient<UpdateUserRequestValidator>();

            services.AddTransient<CreateRoomRequestValidator>();
            services.AddTransient<UpdateRoomRequestValidator>();


            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }

    }
}
