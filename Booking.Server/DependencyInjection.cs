using Booking.Client.DTOs.Mappings;
using Booking.Client.Repositories;
using Booking.Client.Repositories.Interfaces;
using Booking.Client.Services;
using Booking.Client.Services.Interfaces;
using Booking.Client.Utils;
using Booking.Server.Repositories;
using Booking.Server.Repositories.Interfaces;


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

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }

    }
}
