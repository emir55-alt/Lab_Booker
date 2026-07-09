namespace LabBooker.Application.Tests;
using LabBooker.Application.Common;
public class UnitTest1
{
    [Fact]
    public void Result_Succes_Test()
    {
        var result = Result<int>.Success(42);
        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.Null(result.Error);
    }
    [Fact]
    public void Result_Failure_Test()
    {
        var result = Result<int>.Failure("Fehler");
        Assert.False(result.IsSuccess);
        Assert.Equal("Fehler", result.Error);
        Assert.NotNull(result.Error);
    }
}
