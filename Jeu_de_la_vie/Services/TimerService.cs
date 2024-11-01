using System;
using System.Timers;

namespace Jeu_de_la_vie.Services;

public class TimerService : ITimerService
{
    private readonly Timer timer;

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

    public void Start() => timer.Start();

    public void Stop() => timer.Stop();
}