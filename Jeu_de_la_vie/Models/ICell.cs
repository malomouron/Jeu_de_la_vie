namespace Jeu_de_la_vie.Models;

public interface ICell
{
    bool IsAlive { get; set; }     // Indique si la cellule est vivante ou morte
    void ToggleState();             // Change l'état de la cellule (vivante/morte)
    int X { get; }                  // Position X de la cellule
    int Y { get; }                  // Position Y de la cellule
}