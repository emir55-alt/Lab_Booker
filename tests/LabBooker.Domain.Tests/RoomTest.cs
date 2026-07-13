using LabBooker.Domain.Entities;
using LabBooker.Domain.Enums;
using LabBooker.Domain.ValueObjects;

namespace LabBooker.Domain.Tests;

public class RoomTest
{
    [Fact]
    public void Room_Reservieren_Test()
    {
        Room ro1 = new Room("B3.10", "Multifunktionslabor");
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10);
        TimeRange tr = new TimeRange(dt, new TimeSpan(1,0,0));
        Requester r1 = new Requester{Name = "Krislaty Gerd"};

        Assert.True(ro1.Reservieren(r1, Priority.Schularbeit, tr).IsSuccess);
        Assert.Equal("Es gibt eine Buchung mit höherer Priorität in diesem Zeitraum!",ro1.Reservieren(r1, Priority.Unterricht, tr).Error);
        
        Room ro2 = new Room("B4.10", "Multifunktionslabor");
        
        Assert.True(ro2.Reservieren(r1, Priority.Schularbeit, tr).IsSuccess);
        Assert.True(ro2.Reservieren(r1, Priority.Matura, tr).IsSuccess);
        Assert.Single(ro2.Bookings);
    }
    
    [Fact]
    public void Room_Reservieren_GleichePriority_Test()
    {
        Room ro1 = new Room("B3.10", "Multifunktionslabor");
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10);
        TimeRange tr = new TimeRange(dt, new TimeSpan(1,0,0));
        Requester r1 = new Requester{Name = "Krislaty Gerd"};

        Assert.True(ro1.Reservieren(r1, Priority.Schularbeit, tr).IsSuccess);
        Assert.Equal("Es gibt eine Buchung mit höherer Priorität in diesem Zeitraum!",ro1.Reservieren(r1, Priority.Unterricht, tr).Error);
        Assert.Equal("Es gibt eine Buchung mit höherer Priorität in diesem Zeitraum!", ro1.Reservieren(r1, Priority.Unterricht, tr).Error);
    }
    
    [Fact]
    public void Room_Reservieren_NoOverlaps_Test()
    {
        Room ro1 = new Room("B3.10", "Multifunktionslabor");
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10);
        DateTime dt2 = tomorrow.AddHours(14);
        TimeRange tr = new TimeRange(dt, new TimeSpan(1,0,0));
        TimeRange tr2 = new TimeRange(dt2, new TimeSpan(1,0,0));
        Requester r1 = new Requester{Name = "Krislaty Gerd"};

        Assert.True(ro1.Reservieren(r1, Priority.Schularbeit, tr).IsSuccess);
        Assert.True(ro1.Reservieren(r1, Priority.Schularbeit, tr2).IsSuccess);        
    }
}