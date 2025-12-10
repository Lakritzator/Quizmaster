using System;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System.Globalization;
using System.Collections.Generic;

namespace Quizmaster.Converters
{
    public class AnswerResultToColorConverter : IMultiValueConverter
    {
        // values[0]: IsCorrect (bool)
        // values[1]: IsSelected (bool)
        // values[2]: ShowResult (bool)
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool showResult = values.Length > 2 && values[2] is bool b3 && b3;
            if (!showResult) {
                return Brushes.Transparent;
            }
            bool isCorrect = values[0] is bool b1 && b1;
            bool isSelected = values[1] is bool b2 && b2;

            if (isCorrect)
            {
                return Brushes.Green;
            }
            if (isSelected)
            {
                return Brushes.Red;
            }
            return Brushes.Gray;
        }

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            // Ensure compatibility with the object[] overload
            var array = new object[values.Count];
            values.CopyTo(array, 0);
            return Convert(array, targetType, parameter, culture);
        }
    }
}