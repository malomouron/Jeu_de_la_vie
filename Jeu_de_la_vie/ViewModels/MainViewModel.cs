using System.Collections.ObjectModel;
using System.Windows.Input;
using Jeu_de_la_vie.Models;
using Jeu_de_la_vie.Services;
using Jeu_de_la_vie.Utilities;

namespace Jeu_de_la_vie.ViewModels;

public class MainViewModel : IMainViewModel
{
    private readonly IGameGrid gameGrid;
    private readonly ITimerService timerService;
    private readonly IGameLogicService gameLogicService;

    public ObservableCollection<ICellViewModel> Cells { get; private set; }

    public ICommand StartCommand { get; }
    public ICommand StopCommand { get; }
    public ICommand ResetCommand { get; }

    public MainViewModel(IGameGrid gameGrid, ITimerService timerService, IGameLogicService gameLogicService)
    {
        this.gameGrid = gameGrid;
        this.timerService = timerService;
        this.gameLogicService = gameLogicService;

        Cells = new ObservableCollection<ICellViewModel>();
        InitializeCells();

        StartCommand = new RelayCommand(_ => StartGame(), _ => !timerService.IsRunning);
        StopCommand = new RelayCommand(_ => StopGame(), _ => timerService.IsRunning);
        ResetCommand = new RelayCommand(_ => ResetGrid());

        timerService.Tick += (s, e) => UpdateGrid();
    }

    private void InitializeCells()
    {
        Cells.Clear();
        for (int x = 0; x < gameGrid.Rows; x++)
        {
            for (int y = 0; y < gameGrid.Columns; y++)
            {
                Cells.Add(new CellViewModel(gameGrid.GetCell(x, y)));
            }
        }
    }

    private void StartGame() => timerService.Start();

    private void StopGame() => timerService.Stop();

    private void ResetGrid()
    {
        gameGrid.InitializeGrid();
        InitializeCells();
    }

    private void UpdateGrid()
    {
        gameGrid.UpdateGrid();
        foreach (var cellViewModel in Cells)
        {
            cellViewModel.OnPropertyChanged(nameof(cellViewModel.IsAlive));
        }
    }
}
