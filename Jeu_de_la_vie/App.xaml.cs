using System;
using Jeu_de_la_vie.ViewModels;
using Jeu_de_la_vie.Views;

namespace Jeu_de_la_vie;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    /// <summary>
    /// Application Entry for Jeu_de_la_vie
    /// </summary>
    public App()
    {
        var view = new MainView
        {
            DataContext = Activator.CreateInstance<MainViewModel>()
        };

        view.Show();
    }
}