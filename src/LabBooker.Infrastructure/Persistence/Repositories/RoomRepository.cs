using LabBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabBooker.Infrastructure.Persistence.Repositories;
using LabBooker.Application.Interfaces;

public class RoomRepository: IRoomRepository
{
    private readonly LabBookerDbContext _context;

    public RoomRepository(LabBookerDbContext context) 
    {
        _context = context;
    }
    public async Task<Room?> GetIdByAsync(string roomId)
    {
        return await _context.Rooms.Include(r => r.Bookings).FirstOrDefaultAsync(r => r.RoomId == roomId);
    }

    public async Task SaveAsync(Room room)
    {
        var existiert = await _context.Rooms.AnyAsync(r => r.RoomId == room.RoomId);
        if (existiert)
        {
            _context.Rooms.Update(room);
        }
        else
        {
            _context.Rooms.Add(room);
        }
        await _context.SaveChangesAsync();
    }
}