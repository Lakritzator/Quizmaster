using System;
using Avalonia.Data.Converters;
using System.Globalization;
using System.Collections.Generic;

namespace Quizmaster.Converters
{
    public class AnswerResultToIconConverter : IMultiValueConverter
    {
        // values[0]: IsCorrect (bool)
        // values[1]: IsSelected (bool)
        // values[2]: ShowResult (bool)
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 || !(values[2] is bool showResult) || !showResult)
                return string.Empty;

            bool isCorrect = values[0] is bool b1 && b1;
            bool isSelected = values[1] is bool b2 && b2;

            if (isCorrect)
                return "✔";
            if (isSelected)
                return "✖";
            return string.Empty;
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