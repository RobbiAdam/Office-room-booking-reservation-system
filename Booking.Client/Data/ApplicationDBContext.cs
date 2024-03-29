using Booking.Client.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Client.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)       
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Room)
                .WithMany(r => r.Meetings)
                .HasForeignKey(m => m.RoomId);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.User)
                .WithMany(u => u.Meetings)
                .HasForeignKey(m => m.UserId);
        }

    }
}
