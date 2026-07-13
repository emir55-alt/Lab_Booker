namespace LabBooker.Application.Tests;

using Moq;
using LabBooker.Application.UseCases;
using LabBooker.Application.Interfaces;
using LabBooker.Domain.Entities;
using LabBooker.Domain.ValueObjects;
using LabBooker.Domain.Enums;

public class ReserveRoomTests
{
    [Fact]
    public async Task ExecuteAsync_BeiExistierendemRaum_GibtErfolgZurueck()
    {
        var room = new Room("B3.10", "Multifunktionslabor");
        var mockRepo = new Mock<IRoomRepository>();
        mockRepo.Setup(r => r.GetIdByAsync("B3.10")).ReturnsAsync(room);

        var useCase = new ReserveRoom(mockRepo.Object);

        DateTime tomorrow = DateTime.Today.AddDays(1);
        var timeRange = new TimeRange(tomorrow.AddHours(10), new TimeSpan(1, 0, 0));
        var requester = new Requester { Name = "Test Requester" };
        
        var result = await useCase.ExecuteAsync("B3.10", requester, Priority.Matura, timeRange);
        
        Assert.True(result.IsSuccess);
        mockRepo.Verify(r => r.SaveAsync(room), Times.Once);
    }
    
    [Fact]
    public async Task ExecuteAsync_BeiNichtExistierendemRaum_GibtNullZurueck()
    {
        var room = new Room("B3.10", "Multifunktionslabor");
        var mockRepo = new Mock<IRoomRepository>();
        mockRepo.Setup(r => r.GetIdByAsync("B3.10")).ReturnsAsync((Room?)null);

        var useCase = new ReserveRoom(mockRepo.Object);

        DateTime tomorrow = DateTime.Today.AddDays(1);
        var timeRange = new TimeRange(tomorrow.AddHours(10), new TimeSpan(1, 0, 0));
        var requester = new Requester { Name = "Test Requester" };
        
        var result = await useCase.ExecuteAsync("B3.10", requester, Priority.Matura, timeRange);
        
        Assert.Equal($"Es gibt kein Room mit B3.10! ",result.Error);
        mockRepo.Verify(r => r.SaveAsync(It.IsAny<Room>()), Times.Never);
    }
}