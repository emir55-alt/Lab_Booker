namespace LabBooker.Domain.Entities;
using LabBooker.Domain.ValueObjects;
using LabBooker.Domain.Enums;

public class Booking
{
    public Guid BookingId { get; init; }
    public string RoomId { get; init; }
    public Requester Requester { get; init; }
    public Priority Priority { get; init; }  
    public TimeRange TimeRange { get; init; }

    internal Booking(string roomId, Requester requester, Priority priority, TimeRange timeRange)
    {
        BookingId = Guid.NewGuid();
        if (roomId == null || string.IsNullOrWhiteSpace(roomId))
        {
            throw new ArgumentException("Es muss ein Raum angegeben werden!");
        }
        RoomId = roomId;
        Requester = requester;
        Priority = priority;
        TimeRange = timeRange;
    }
    private Booking() { }
}