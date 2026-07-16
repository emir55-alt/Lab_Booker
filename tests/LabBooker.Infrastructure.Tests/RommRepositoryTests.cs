using LabBooker.Domain.Entities;
using LabBooker.Domain.Enums;
using LabBooker.Domain.ValueObjects;
using LabBooker.Infrastructure.Persistence;
using LabBooker.Infrastructure.Persistence.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LabBooker.Infrastructure.Tests;

public class RommRepositoryTests
{
    private readonly SqliteConnection _connection;
    private readonly LabBookerDbContext _context;

    public RommRepositoryTests()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<LabBookerDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new LabBookerDbContext(options);
        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
    }

    [Fact]
    public async Task SaveAsync_SpeichertRaummitBuchung_Korrekt()
    {
        var repository = new RoomRepository(_context);
        var room = new Room("B3.10", "Multifunktionslabor");
        
        DateTime tomorrow = DateTime.Today.AddDays(1);
        var timeRange = new TimeRange(tomorrow.AddHours(10), new TimeSpan(1, 0, 0));
        var requester = new Requester { Name = "Test Requester" };

        room.Reservieren(requester, Priority.Matura, timeRange);
        
        await repository.SaveAsync(room);

        var foundRoom = await repository.GetIdByAsync("B3.10");

        Assert.NotNull(foundRoom);
        Assert.Equal("B3.10", foundRoom.RoomId);
        Assert.Equal(requester, foundRoom.Bookings.FirstOrDefault().Requester);
        Assert.Equal(timeRange, foundRoom.Bookings.FirstOrDefault().TimeRange);
    }
}