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
        private Color UpLabelColor = Color.FromArgb("#343A40");
        private Color DownLabelColor = Color.FromArgb("#ADB5BD");
        private Color UpStrokeColor = Color.FromArgb("#343A40");
        private Color DownStrokeColor = Color.FromArgb("#DEE2E6");
         
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
                "Activated" => UpStrokeColor,
                "Deactivated" => DownStrokeColor,
                _ => DownStrokeColor
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
