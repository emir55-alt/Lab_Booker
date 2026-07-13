using LabBooker.Application.Common;
using LabBooker.Domain.ValueObjects;
using LabBooker.Domain.Enums;
namespace LabBooker.Domain.Entities;


public class Room
{
    public string RoomId { get; init; }
    public string RaumBezeichnung { get; init; }
    private readonly List<Booking> _bookings = new();
    public IReadOnlyList<Booking> Bookings => _bookings;

    public Room(string roomId, string raumBezeichnung)
    {
        if (roomId == null || string.IsNullOrWhiteSpace(roomId))
        {
            throw new ArgumentException("Es muss eine Raum-ID angegeben werden!");
        }
        if (raumBezeichnung == null || string.IsNullOrWhiteSpace(raumBezeichnung))
        {
            throw new ArgumentException("Es muss eine Raumbezeichnung angegeben werden!");
        }
        RoomId = roomId;
        RaumBezeichnung = raumBezeichnung;
    }

    public Result<Booking> Reservieren(Requester requester, Priority priority, TimeRange timeRange)
    {
        Booking kollidierBuchung = _bookings.FirstOrDefault(b => b.TimeRange.Overlaps(timeRange));
        if (kollidierBuchung == null)
        {
            Booking b = new Booking(this.RoomId, requester, priority, timeRange);
            _bookings.Add(b);
            return Result<Booking>.Success(b);
        }
        if (kollidierBuchung.Priority >= priority)
        {
            return Result<Booking>.Failure("Es gibt eine Buchung mit höherer Priorität in diesem Zeitraum!");
        }
        _bookings.Remove(kollidierBuchung);
        Booking b2 = new Booking(this.RoomId, requester, priority, timeRange);
        _bookings.Add(b2);
        return Result<Booking>.Success(b2);
    }
}