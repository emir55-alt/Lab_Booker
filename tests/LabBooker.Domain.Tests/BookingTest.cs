using LabBooker.Domain.Entities;
using LabBooker.Domain.Enums;
using LabBooker.Domain.ValueObjects;

namespace LabBooker.Domain.Tests;

public class BookingTest
{
    [Fact]
    public void Booking_Konstruktor_Exception_Test()
    {
        Requester r1 = new Requester{Name = "Manfred Knon"};
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10);
        TimeRange t1 = new TimeRange(dt, new TimeSpan(1, 0, 0));

        Assert.Throws<ArgumentException>(() => new Booking("", r1, Priority.Matura, t1));
    }
    
    [Fact]
    public void Booking_Konstruktor_Valid_Test()
    {
        Requester r1 = new Requester{Name = "Manfred Knon"};
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10);
        TimeRange t1 = new TimeRange(dt, new TimeSpan(1, 0, 0));
        Room ro1 = new Room("B3.10", "Multifunktionslabor");
        Booking b = new Booking(ro1.RoomId, r1, Priority.Schularbeit, t1);

        Assert.Equal("B3.10", b.RoomId);
        Assert.Equal(r1, b.Requester);
        Assert.Equal(Priority.Schularbeit, b.Priority);
        Assert.Equal(t1, b.TimeRange);
    }
}