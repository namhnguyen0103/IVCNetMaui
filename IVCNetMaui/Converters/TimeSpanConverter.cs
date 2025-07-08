using System.Globalization;

namespace IVCNetMaui.Converters;

public class TimeSpanConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TimeSpan span)
        {
            return $"{(int)span.TotalDays:0} day {span.Hours:0} hr {span.Minutes:0} min {span.Seconds:0} sec";
        }
        return "0 day 0 hr 0 min 0 sec";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}