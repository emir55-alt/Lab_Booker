namespace LabBooker.Domain.Tests;
using LabBooker.Domain.Enums;
using LabBooker.Domain.ValueObjects;
public class LogicTest
{
    [Fact]
    public void Priority_Right_Test()
    {
        Assert.True(Priority.Matura > Priority.Unterricht);
    }
    
    [Fact]
    public void Requester_Equals_Test()
    {
        Requester r1 = new Requester{Name = "Manfred Knon"};
        Requester r2 = new Requester { Name = "Manfred Knon" };
        Assert.Equal(r1, r2);
    }
    [Fact]
    public void Overlaps_Test()
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
}
