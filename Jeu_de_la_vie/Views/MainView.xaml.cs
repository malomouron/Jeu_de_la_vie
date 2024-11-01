
using System.Windows;
using Jeu_de_la_vie.Models;
using Jeu_de_la_vie.Services;
using Jeu_de_la_vie.ViewModels;

namespace Jeu_de_la_vie.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Initialisation des services et du ViewModel
        IGameGrid gameGrid = new GameGrid(2, 2, new GameLogicService());
        ITimerService timerService = new TimerService(200); // Intervalle de 500 ms
        IGameLogicService gameLogicService = new GameLogicService();

        // Création du ViewModel principal avec les services injectés
        DataContext = new MainViewModel(gameGrid, timerService, gameLogicService);
    }
}