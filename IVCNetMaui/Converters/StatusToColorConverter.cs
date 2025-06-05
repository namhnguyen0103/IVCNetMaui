using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVCNetMaui.Converters
{
    internal class StatusToColorConverter : IValueConverter
    {
        private Color UpLabelColor = Color.FromArgb("#FFFFFF");
        private Color DownLabelColor = Color.FromArgb("#ADB5BD");
        private Color UpBackgroundColor = Color.FromArgb("#53A5FF");
        private Color DownBackgroundColor = Color.FromArgb("#E9ECEE");
         
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? caller = parameter?.ToString();

            if (caller == "Label")
            {
                return value switch
                {
                    "Activated" => UpLabelColor,
                    "Deactivated" => DownLabelColor,
                    _ => DownLabelColor
                };
            }

            return value switch
            {
                "Activated" => UpBackgroundColor,
                "Deactivated" => DownBackgroundColor,
                _ => DownBackgroundColor
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
