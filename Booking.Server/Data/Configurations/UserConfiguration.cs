using Booking.Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Server.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.HasMany(u => u.OrganizedMeetings)
                .WithOne(m => m.Organizer)
                .HasForeignKey(m => m.OrganizerId);

        }
    }
}
