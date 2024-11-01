namespace Jeu_de_la_vie.Models;

public class Cell : ICell
{
    public bool IsAlive { get; set; }          // Indique si la cellule est vivante ou morte
    public int X { get; }                      // Position X de la cellule
    public int Y { get; }                      // Position Y de la cellule

    public Cell(int x, int y, bool isAlive = false)
    {
        X = x;
        Y = y;
        IsAlive = isAlive;
    }

    // Méthode pour inverser l'état de la cellule
    public void ToggleState()
    {
        IsAlive = !IsAlive;
    }
}