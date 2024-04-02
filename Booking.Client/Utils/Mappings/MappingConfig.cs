using Booking.Client.Models;
using Booking.Client.Responses.Users;
using Mapster;

namespace Booking.Client.Utils.Mappings
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            TypeAdapterConfig<List<User>, GetUsersResponses>.NewConfig()
                .Map(dest => dest, src => src);

            TypeAdapterConfig<User, GetUserByIdResponse>.NewConfig()
                .Map(dest => dest, src => src);
        }
    }
}
