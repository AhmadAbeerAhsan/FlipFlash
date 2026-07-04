using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FlipFlash.Helpers
{
    public class DateToRelativeStringConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not DateTime)
            {
                throw new ArgumentException("Expected date value");
            }
            // Differenz zwischen dem aktuellen und
            // dem übergebenen Datum berechnen
            DateTime today = DateTime.Today;
            var difference = ((DateTime)value - today).Days;
            // Unterschied in natürliche Sprache umwandeln
            // und zurückgeben
            return difference switch
            {
                0 => "Heute",
                1 => "Morgen",
                -1 => "Gestern",
                < -7 => string.Format("Vor {0} Tagen", Math.Abs(difference)),
                < 0 => "Letzte Woche",
                < 7 => string.Format("In {0} Tagen", difference),
                < 14 => "Nächste Woche",
                < 21 => "In zwei Wochen",
                < 28 => "In drei Wochen",
                _ => "In über einem Monat"
            };
        }
        public object ConvertBack
        (
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        ) => throw new NotImplementedException();
    }
}
