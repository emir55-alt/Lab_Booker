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

    internal Booking(string rId, Requester rq, Priority pr, TimeRange tr )
    {
        BookingId = Guid.NewGuid();
        if (rId == null || string.IsNullOrWhiteSpace(rId))
        {
            throw new ArgumentException("Es muss ein Raum angegeben werden!");
        }
        RoomId = rId;
        Requester = rq;
        Priority = pr;
        TimeRange = tr;
    }
}