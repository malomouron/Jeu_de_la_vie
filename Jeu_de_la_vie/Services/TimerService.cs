using System;
using System.Timers;

namespace Jeu_de_la_vie.Services;

public class TimerService : ITimerService
{
    private readonly Timer timer;
    private bool _isRunning;

    public TimerService(int interval)
    {
        timer = new Timer(interval);
        timer.Elapsed += (sender, e) => Tick?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler Tick;

    public int Interval
    {
        get => (int)timer.Interval;
        set => timer.Interval = value;
    }

    public bool IsRunning => _isRunning;

    public void Start()
    {
        timer.Start();
        _isRunning = true;
    }

    public void Stop()
    {
        timer.Stop();
        _isRunning = false;
    }
}