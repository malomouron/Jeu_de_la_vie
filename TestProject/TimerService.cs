using Jeu_de_la_vie.Services;
using Xunit;

namespace TestProject;

public class TimerServiceTests
{
    [Fact]
    public void Start_ShouldSetIsRunningToTrue()
    {
        var timerService = new TimerService(500);
        timerService.Start();
        Assert.True(timerService.IsRunning);
    }

    [Fact]
    public void Stop_ShouldSetIsRunningToFalse()
    {
        var timerService = new TimerService(500);
        timerService.Start();
        timerService.Stop();
        Assert.False(timerService.IsRunning);
    }

    [Fact]
    public void Interval_ShouldSetAndGetCorrectly()
    {
        var timerService = new TimerService(500);
        timerService.Interval = 1000;
        Assert.Equal(1000, timerService.Interval);
    }
}