using System.Collections.Generic;
using System.Linq;
using Jeu_de_la_vie.Models;

namespace Jeu_de_la_vie.Services;

public class GameLogicService : IGameLogicService
{
    public void ApplyRules(ICell cell, IEnumerable<ICell> neighbors)
    {
        int aliveNeighbors = neighbors.Count(n => n.IsAlive);

        if (cell.IsAlive && (aliveNeighbors < 2 || aliveNeighbors > 3))
        {
            cell.ToggleState();
        }
        else if (!cell.IsAlive && aliveNeighbors == 3)
        {
            cell.ToggleState();
        }
    }

    public List<ICell> GetCellsToToggle(IEnumerable<ICell> cells)
    {
        var cellsToToggle = new List<ICell>();

        foreach (var cell in cells)
        {
            var neighbors = GetNeighbors(cell);
            int aliveNeighbors = neighbors.Count(n => n.IsAlive);

            if ((cell.IsAlive && (aliveNeighbors < 2 || aliveNeighbors > 3)) ||
                (!cell.IsAlive && aliveNeighbors == 3))
            {
                cellsToToggle.Add(cell);
            }
        }

        return cellsToToggle;
    }

    private IEnumerable<ICell> GetNeighbors(ICell cell)
    {
        // Supposons que cette méthode sera remplie dans GameGrid pour fournir les voisins
        return new List<ICell>();
    }
}