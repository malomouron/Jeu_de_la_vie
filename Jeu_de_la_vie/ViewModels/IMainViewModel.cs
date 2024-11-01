using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Jeu_de_la_vie.ViewModels;

public interface IMainViewModel
{
    ObservableCollection<ICellViewModel> Cells { get; } // Collection de cellules à afficher
    ICommand StartCommand { get; }                      // Commande pour démarrer le jeu
    ICommand StopCommand { get; }                       // Commande pour arrêter le jeu
    ICommand ResetCommand { get; }                      // Commande pour réinitialiser la grille
}