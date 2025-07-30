using System.Globalization;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;

namespace IVCNetMaui.Converters;

public class ToPickerItemConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Unit unit)
        {
            return $"{unit.UnitId}) {unit.Name}";
        }

        if (value is Feed feed)
        {
            return $"{feed.FeedId}) {feed.Name}";
        }

        return "Unknown";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}