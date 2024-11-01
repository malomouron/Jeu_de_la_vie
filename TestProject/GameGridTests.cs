using Jeu_de_la_vie.Models;
using Jeu_de_la_vie.Services;
using Xunit;
using Moq;
using System.Collections.Generic;
using System;

namespace TestProject;

public class GameGridTests
{
    [Fact]
    public void InitializeGrid_ShouldInitializeWithCorrectDimensions()
    {
        var gameGrid = new GameGrid(20, 20, new GameLogicService());
        Assert.Equal(20, gameGrid.Rows);
        Assert.Equal(20, gameGrid.Columns);
    }

    [Fact]
    public void GetCell_ShouldReturnCorrectCell()
    {
        var gameGrid = new GameGrid(20, 20, new GameLogicService());
        var cell = gameGrid.GetCell(0, 0);
        Assert.NotNull(cell);
    }

    [Fact]
    public void GetCell_ShouldThrowExceptionForInvalidCoordinates()
    {
        var gameGrid = new GameGrid(20, 20, new GameLogicService());
        Assert.Throws<ArgumentOutOfRangeException>(() => gameGrid.GetCell(-1, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => gameGrid.GetCell(21, 21));
    }

    [Fact]
    public void InitializeGrid_ShouldCreateCellsWithCorrectCoordinates()
    {
        
        var gameLogicServiceMock = new Mock<IGameLogicService>();
        var gameGrid = new GameGrid(20, 20, gameLogicServiceMock.Object);

        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                var cell = gameGrid.GetCell(x, y);
                Assert.Equal(x, cell.X);
                Assert.Equal(y, cell.Y);
            }
        }
    }

    [Fact]
    public void GetCell_ShouldThrowArgumentOutOfRangeExceptionForNegativeCoordinates()
    {
        var gameLogicServiceMock = new Mock<IGameLogicService>();
        var gameGrid = new GameGrid(20, 20, gameLogicServiceMock.Object);

        Assert.Throws<ArgumentOutOfRangeException>(() => gameGrid.GetCell(-1, -1));
    }

    [Fact]
    public void GetCell_ShouldThrowArgumentOutOfRangeExceptionForCoordinatesOutOfBounds()
    {
        var gameLogicServiceMock = new Mock<IGameLogicService>();
        var gameGrid = new GameGrid(20, 20, gameLogicServiceMock.Object);

        Assert.Throws<ArgumentOutOfRangeException>(() => gameGrid.GetCell(20, 20));
    }

    [Fact]
    public void UpdateGrid_ShouldCallApplyRulesOnGameLogicService()
    {
        var gameLogicServiceMock = new Mock<IGameLogicService>();
        var gameGrid = new GameGrid(20, 20, gameLogicServiceMock.Object);

        gameGrid.UpdateGrid();

        gameLogicServiceMock.Verify(service => service.ApplyRules(It.IsAny<ICell>(), It.IsAny<IEnumerable<ICell>>()), Times.AtLeastOnce);
    }

    [Fact]
    public void GetNeighbors_ShouldReturnCorrectNumberOfNeighbors()
    {
        var gameLogicServiceMock = new Mock<IGameLogicService>();
        var gameGrid = new GameGrid(20, 20, gameLogicServiceMock.Object);
        var cell = gameGrid.GetCell(10, 10);

        var neighbors = gameGrid.GetNeighbors(cell);

        Assert.Equal(8, neighbors.Count());
    }

    [Fact]
    public void GetNeighbors_ShouldReturnFewerNeighborsForEdgeCells()
    {
        var gameLogicServiceMock = new Mock<IGameLogicService>();
        var gameGrid = new GameGrid(20, 20, gameLogicServiceMock.Object);
        var cell = gameGrid.GetCell(0, 0);

        var neighbors = gameGrid.GetNeighbors(cell);

        Assert.Equal(3, neighbors.Count());
    }
}