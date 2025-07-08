using System.Globalization;

namespace IVCNetMaui.Converters;

public class ThousandsFormatConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is long number)
        {
            if (number >= 1_000)
                return $"{number / 1_000.0:F0} K";
            return number.ToString();
        }
        return value?.ToString() ?? "";
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}