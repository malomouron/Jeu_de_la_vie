namespace Jeu_de_la_vie.ViewModels;

public interface ICellViewModel
{
    bool IsAlive { get; set; }           // État de la cellule
    void ToggleState();                  // Change l'état de la cellule (vivante/morte)
}