using Jeu_de_la_vie.Models;
using Jeu_de_la_vie.Services;
using Moq;
using Xunit;

namespace TestProject;

public class GameLogicServiceTests
{
    [Fact]
    public void ApplyRules_ShouldToggleState_WhenCellIsAliveAndHasFewerThanTwoAliveNeighbors()
    {
        var cellMock = new Mock<ICell>();
        cellMock.Setup(c => c.IsAlive).Returns(true);
        var neighbors = new List<ICell> { Mock.Of<ICell>(c => c.IsAlive == false) };

        var service = new GameLogicService();
        service.ApplyRules(cellMock.Object, neighbors);

        cellMock.Verify(c => c.ToggleState(), Times.Once);
    }

    [Fact]
    public void ApplyRules_ShouldToggleState_WhenCellIsAliveAndHasMoreThanThreeAliveNeighbors()
    {
        var cellMock = new Mock<ICell>();
        cellMock.Setup(c => c.IsAlive).Returns(true);
        var neighbors = new List<ICell>
        {
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true)
        };

        var service = new GameLogicService();
        service.ApplyRules(cellMock.Object, neighbors);

        cellMock.Verify(c => c.ToggleState(), Times.Once);
    }

    [Fact]
    public void ApplyRules_ShouldToggleState_WhenCellIsDeadAndHasExactlyThreeAliveNeighbors()
    {
        var cellMock = new Mock<ICell>();
        cellMock.Setup(c => c.IsAlive).Returns(false);
        var neighbors = new List<ICell>
        {
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true)
        };

        var service = new GameLogicService();
        service.ApplyRules(cellMock.Object, neighbors);

        cellMock.Verify(c => c.ToggleState(), Times.Once);
    }

    [Fact]
    public void ApplyRules_ShouldNotToggleState_WhenCellIsAliveAndHasTwoOrThreeAliveNeighbors()
    {
        var cellMock = new Mock<ICell>();
        cellMock.Setup(c => c.IsAlive).Returns(true);
        var neighbors = new List<ICell>
        {
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true)
        };

        var service = new GameLogicService();
        service.ApplyRules(cellMock.Object, neighbors);

        cellMock.Verify(c => c.ToggleState(), Times.Never);
    }

    [Fact]
    public void ApplyRules_ShouldNotToggleState_WhenCellIsDeadAndDoesNotHaveExactlyThreeAliveNeighbors()
    {
        var cellMock = new Mock<ICell>();
        cellMock.Setup(c => c.IsAlive).Returns(false);
        var neighbors = new List<ICell>
        {
            Mock.Of<ICell>(c => c.IsAlive == true),
            Mock.Of<ICell>(c => c.IsAlive == true)
        };

        var service = new GameLogicService();
        service.ApplyRules(cellMock.Object, neighbors);

        cellMock.Verify(c => c.ToggleState(), Times.Never);
    }
}