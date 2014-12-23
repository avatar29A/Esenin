using System;
using System.Globalization;
using System.Windows.Data;

namespace Hqub.Esenin.App.Converters
{
    public class PercentToLearnedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int percent = (int)value;

            return percent == 0 ? string.Empty : string.Format("Выучено {0} %", percent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
