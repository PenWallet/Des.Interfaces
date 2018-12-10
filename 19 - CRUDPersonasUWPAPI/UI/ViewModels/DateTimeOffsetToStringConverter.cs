using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UI.ViewModels
{
    public class DateTimeOffsetToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime.ToLongTimeString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset ret;
            DateTimeOffset.TryParse((string)value, out ret);

            return ret;
        }
    }
}
