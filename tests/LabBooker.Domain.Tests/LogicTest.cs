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
}
