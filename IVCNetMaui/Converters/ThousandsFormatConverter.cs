using System.Globalization;

namespace IVCNetMaui.Converters;

public class ThousandsFormatConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is long number)
        {
            if (number >= 1_000_000_000)
                return $"{number / 1_000_000_000.0:F1} GB";
            if (number >= 1_000_000)
                return $"{number / 1_000_000.0:F1} MB";
            if (number >= 1_000)
                return $"{number / 1_000.0:F1} KB";
            return $"{number} B";
        }
        return value != null ? $"{value} B" : "0 B";
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}