using LabBooker.Application.Common;
using LabBooker.Application.Interfaces;
using LabBooker.Domain.Entities;
using LabBooker.Domain.Enums;
using LabBooker.Domain.ValueObjects;

namespace LabBooker.Application.UseCases;

public class ReserveRoom 
{
    private readonly IRoomRepository _roomRepository;

    public ReserveRoom(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    public async Task<Result<Booking>> ExecuteAsync(string roomId, Requester requester, Priority priority, TimeRange timeRange)
    {
        Room? room = await _roomRepository.GetIdByAsync(roomId);
        if (room == null)
        {
            return Result<Booking>.Failure($"Es gibt kein Room mit {roomId}! ");
        }
        var result = room.Reservieren(requester, priority, timeRange);
        if (result.IsSuccess)
        {
            await _roomRepository.SaveAsync(room);
        }
        return result;
    }
}