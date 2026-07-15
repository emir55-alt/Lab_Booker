using LabBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabBooker.Infrastructure.Persistence;

public class LabBookerDbContext : DbContext
{
    public LabBookerDbContext(DbContextOptions<LabBookerDbContext> options) : base(options)
    {
    }
    
    public DbSet<Room> Rooms=> Set<Room>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>(room =>
        {
            room.HasKey(r => r.RoomId);

            room.HasMany<Booking>()
                .WithOne()
                .HasForeignKey(b => b.RoomId);
        });

        modelBuilder.Entity<Booking>(booking =>
        {
            booking.HasKey(b => b.BookingId);

            booking.OwnsOne(b => b.Requester);
            booking.OwnsOne(b => b.TimeRange);
        });
    }
}