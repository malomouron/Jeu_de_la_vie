using System.Collections.Generic;
using Jeu_de_la_vie.Services;

namespace Jeu_de_la_vie.Models;

public class GameGrid : IGameGrid
{
    private readonly ICell[,] cells;
    private readonly IGameLogicService gameLogicService;

    public int Rows { get; }
    public int Columns { get; }

    public GameGrid(int rows, int columns, IGameLogicService gameLogicService)
    {
        Rows = rows;
        Columns = columns;
        cells = new ICell[rows, columns];
        this.gameLogicService = gameLogicService;
        InitializeGrid();
    }

    public void InitializeGrid()
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                cells[x, y] = new Cell(x, y);
            }
        }
    }

    public ICell GetCell(int x, int y)
    {
        if (x < 0 || x >= Rows || y < 0 || y >= Columns)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        return cells[x, y];
    }

    public void UpdateGrid()
    {
        foreach (var cell in cells)
        {
            var neighbors = GetNeighbors(cell);
            gameLogicService.ApplyRules(cell, neighbors);
        }
    }

    public IEnumerable<ICell> GetNeighbors(ICell cell)
    {
     var neighbors = new List<ICell>();

        for (int x = cell.X - 1; x <= cell.X + 1; x++)
        {
            for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
            {
                if (x == cell.X && y == cell.Y)
                    continue;

                if (x >= 0 && x < Rows && y >= 0 && y < Columns)
                {
                    neighbors.Add(GetCell(x, y));
                }
            }
        }

        return neighbors;   
    }
}
