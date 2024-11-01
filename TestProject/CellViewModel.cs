using Jeu_de_la_vie.Models;
using Jeu_de_la_vie.ViewModels;
using Xunit;

namespace TestProject;

public class CellViewModelTests
{
    [Fact]
    public void IsAlive_ShouldReturnCorrectValue()
    {
        var cell = new CellViewModel(new Cell(0, 0));
        Assert.False(cell.IsAlive);
    }

    [Fact]
    public void OnPropertyChanged_ShouldTriggerPropertyChangedEvent()
    {
        var cell = new CellViewModel(new Cell(0, 0));
        bool eventTriggered = false;
        cell.PropertyChanged += (sender, args) => eventTriggered = true;
        cell.OnPropertyChanged(nameof(cell.IsAlive));
        Assert.True(eventTriggered);
    }
}