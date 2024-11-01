using System.Collections.Generic;
using System.Linq;
using Jeu_de_la_vie.Models;

namespace Jeu_de_la_vie.Services
{
    /// <summary>
    /// Service de logique de jeu pour appliquer les règles du jeu de la vie.
    /// </summary>
    public class GameLogicService : IGameLogicService
    {
        /// <summary>
        /// Applique les règles du jeu de la vie à une cellule donnée en fonction de ses voisins.
        /// </summary>
        /// <param name="cell">La cellule à laquelle appliquer les règles.</param>
        /// <param name="neighbors">Les voisins de la cellule.</param>
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
    }
}