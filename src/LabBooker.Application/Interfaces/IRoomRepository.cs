namespace LabBooker.Application.Interfaces;
using LabBooker.Domain.Entities;

public interface IRoomRepository
{
    Task<Room?> GetIdByAsync(string roomId);
    Task SaveAsync(Room room);
}