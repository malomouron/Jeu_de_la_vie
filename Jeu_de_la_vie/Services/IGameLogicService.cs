using System.Collections.Generic;
using Jeu_de_la_vie.Models;

namespace Jeu_de_la_vie.Services;

public interface IGameLogicService
{
    ICell ApplyRules(ICell cell, IEnumerable<ICell> neighbors); // Applique les règles de Conway à une cellule
}