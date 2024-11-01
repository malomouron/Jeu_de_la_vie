using System.Collections.Generic;

namespace Jeu_de_la_vie.Models;

public class GameGrid : IGameGrid
{
    private readonly ICell[,] cells;            // Grille de cellules
    public int Rows { get; }                    // Nombre de lignes dans la grille
    public int Columns { get; }                 // Nombre de colonnes dans la grille

    public GameGrid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        cells = new ICell[rows, columns];
        InitializeGrid();
    }

    // Initialisation de la grille avec des cellules mortes par défaut
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

    // Récupère une cellule à une position donnée
    public ICell GetCell(int x, int y) => cells[x, y];

    // Mise à jour de la grille pour la génération suivante
    public void UpdateGrid()
    {
        var cellsToToggle = new List<ICell>();

        foreach (var cell in cells)
        {
            var aliveNeighbors = CountAliveNeighbors(cell);
            if (cell.IsAlive && (aliveNeighbors < 2 || aliveNeighbors > 3))
            {
                cellsToToggle.Add(cell);
            }
            else if (!cell.IsAlive && aliveNeighbors == 3)
            {
                cellsToToggle.Add(cell);
            }
        }

        // Met à jour l'état des cellules en fonction de la règle de Conway
        foreach (var cell in cellsToToggle)
        {
            cell.ToggleState();
        }
    }

    // Obtient les voisins d'une cellule
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

    // Compte le nombre de voisins vivants d'une cellule
    private int CountAliveNeighbors(ICell cell)
    {
        int count = 0;
        foreach (var neighbor in GetNeighbors(cell))
        {
            if (neighbor.IsAlive)
            {
                count++;
            }
        }
        return count;
    }
}