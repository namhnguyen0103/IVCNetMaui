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
         
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
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

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
