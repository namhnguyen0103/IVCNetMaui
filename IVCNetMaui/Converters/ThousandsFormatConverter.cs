using System.Globalization;

namespace IVCNetMaui.Converters;

public class ThousandsFormatConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is long bytes)
        {
            if (bytes >= 1_000_000_000)
            {
                return $"{bytes / 1_000_000_000.0:F1} GB";
            }

            if (bytes >= 1_000_000)
            {
                return $"{bytes / 1_000_000.0:F1} MB";
            }
            if (bytes >= 1_000)
                return $"{bytes / 1_000.0:F1} KB";
            return $"{bytes:F1} B";
        }

        if (ParamIsBps(parameter))
        {
            if (value is double bps)
            {
                if (bps >= 1_000_000_000)
                {
                    return $"{bps / 1_000_000_000.0:F1} Gbps";
                }

                if (bps >= 1_000_000)
                {
                    return $"{bps / 1_000_000.0:F1} Mbps";
                }
                if (bps >= 1_000)
                    return $"{bps / 1_000.0:F1} Kbps";
                return $"{bps:F1} bps";
            }
        }
        return value != null ? ParamIsBps(parameter) ? $"{value} bps" : $"{value} B": "0 B";
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotImplementedException();

    private bool ParamIsBps(object? param) => param is string and "BitsPerSecond";
}