using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlipFlash.Resources.strings;

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
                0 => AppResources.Today,
                1 => AppResources.Tomorrow,
                -1 => AppResources.Yesterday,
                < -7 => string.Format(AppResources.X_Days_Ago, Math.Abs(difference)),
                < 0 => AppResources.Last_Week,
                < 7 => string.Format(AppResources.In_X_Days, difference),
                < 14 => AppResources.Next_Week,
                < 21 => AppResources.In_Two_Weeks,
                < 28 => AppResources.In_Three_Weeks,
                _ => AppResources.InMoreThanAMonth
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
