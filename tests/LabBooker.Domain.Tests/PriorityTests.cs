using LabBooker.Domain.Enums;

namespace LabBooker.Domain.Tests;


public class PriorityTests
{
    [Fact]
    public void Priority_Right_Test()
    {
        Assert.True(Priority.Matura > Priority.Unterricht);
    }
}