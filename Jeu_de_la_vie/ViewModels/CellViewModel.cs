using System.ComponentModel;
using Jeu_de_la_vie.Models;

namespace Jeu_de_la_vie.ViewModels;

public class CellViewModel : INotifyPropertyChanged, ICellViewModel
{
    private readonly ICell cell;

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

    public void ToggleState()
    {
        cell.ToggleState();
        OnPropertyChanged(nameof(IsAlive));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}