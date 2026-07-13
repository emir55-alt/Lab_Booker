using LabBooker.Domain.ValueObjects;

namespace LabBooker.Domain.Tests;

public class RequesterTest
{
    [Fact]
    public void Requester_Equal_Test()
    {
        Requester r1 = new Requester{Name = "Manfred Knon"};
        Requester r2 = new Requester { Name = "Manfred Knon" };
        Assert.Equal(r1, r2);
    }
    [Fact]
    public void Requester_NotEqual_Test()
    {
        Requester r1 = new Requester{Name = "Manfred Knon"};
        Requester r2 = new Requester { Name = "Krislaty Gerd" };
        Assert.NotEqual(r1, r2);
    }
}