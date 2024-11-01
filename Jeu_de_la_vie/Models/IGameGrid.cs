using System.Collections.Generic;

namespace Jeu_de_la_vie.Models;

public interface IGameGrid
{
    int Rows { get; }                          // Nombre de lignes dans la grille
    int Columns { get; }                       // Nombre de colonnes dans la grille
    ICell GetCell(int x, int y);               // Récupère une cellule à une position spécifique
    void InitializeGrid();                     // Initialise la grille avec des cellules
    void UpdateGrid();                         // Met à jour l'état de chaque cellule pour la génération suivante
    IEnumerable<ICell> GetNeighbors(ICell cell); // Obtient les voisins d'une cellule
}