using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Jeu_de_la_vie.Views;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isAlive = (bool)value;
        return isAlive ? Brushes.Black : Brushes.White;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            return brush.Color == Colors.Black;
        }
        throw new InvalidOperationException("Invalid conversion");
    }
}
