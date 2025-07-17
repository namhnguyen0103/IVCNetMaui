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
        private readonly Color _upColor = Color.FromArgb("#66A80A");
        private readonly Color _downColor = Color.FromArgb("#B71C0B");
        private readonly Color _unknownColor = Color.FromArgb("#21252");
        
        private readonly Color _upBackgroundColor = Color.FromArgb("#EEF9DF");
        private readonly Color _downBackgroundColor = Color.FromArgb("#F9E0DF");
        private readonly Color _unknownBackgroundColor = Color.FromArgb("#E9ECEE");
         
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? caller = parameter?.ToString();

            if (caller == "Label")
            {
                return value switch
                {
                    "Active" => _upColor,
                    "Running" => _upColor,
                    "Up" => _upColor,
                    "Deactivated" => _downColor,
                    _ => _unknownColor,
                };
            }
            return value switch
            {
                "Active" => _upBackgroundColor,
                "Running" => _upBackgroundColor,
                "Up" => _upBackgroundColor,
                "Deactivated" => _downBackgroundColor,
                _ => _unknownBackgroundColor,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
