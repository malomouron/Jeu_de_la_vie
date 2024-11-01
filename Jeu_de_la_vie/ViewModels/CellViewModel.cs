using System.ComponentModel;
using Jeu_de_la_vie.Models;

namespace Jeu_de_la_vie.ViewModels;

public class CellViewModel : ICellViewModel
{
    private readonly ICell cell;         // Modèle de la cellule

    public CellViewModel(ICell cell)
    {
        this.cell = cell;
    }

    public bool IsAlive
    {
        get => cell.IsAlive;
        set
        {
            if (cell.IsAlive != value)
            {
                cell.IsAlive = value;
                OnPropertyChanged(nameof(IsAlive));
            }
        }
    }

    public void ToggleState() => cell.ToggleState();

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
