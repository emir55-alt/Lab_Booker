using LabBooker.Domain.ValueObjects;

namespace LabBooker.Domain.Tests;

public class TimeRangeTest
{
    [Fact]
    public void TimeRange_Overlaps_Test()
    {
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10); 
        DateTime dt2 = tomorrow.AddHours(14);
        TimeRange t1 = new TimeRange(dt, new TimeSpan(1, 0, 0));
        TimeRange t2 = new TimeRange(dt2, new TimeSpan(1, 0, 0));
        TimeRange t3 = new TimeRange(dt, new TimeSpan(5, 0, 0));
        
        Assert.False(t1.Overlaps(t2));
        Assert.True(t3.Overlaps(t2));
    }
    
    [Fact]
    public void TimeRange_Konstruktor_Test()
    {
        DateTime tomorrow = DateTime.Today.AddDays(-1);
        DateTime dt = tomorrow.AddHours(10); 
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new TimeRange(dt, new TimeSpan(5, 0, 0)));
    }
    
    [Fact]
    public void TimeRange_Grenzfall_Test()
    {
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime dt = tomorrow.AddHours(10); 
        DateTime dt2 = tomorrow.AddHours(11);
        TimeRange t1 = new TimeRange(dt, new TimeSpan(1, 0, 0));
        TimeRange t2 = new TimeRange(dt2, new TimeSpan(1, 0, 0));
        
        Assert.False(t2.Overlaps(t1));
    }
}