using System;

namespace Jeu_de_la_vie.Services;

public interface ITimerService
{
    event EventHandler Tick;                 // Événement déclenché à chaque intervalle de temps
    void Start();                            // Démarre le timer
    void Stop();                             // Arrête le timer
    int Interval { get; set; }               // Intervalle de temps entre chaque Tick
}