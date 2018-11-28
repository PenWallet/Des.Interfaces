using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Entidades;

namespace ViewModels
{
    public class ClsPersonaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ClsPersona persona = null;
            if (value != null)
                persona = (ClsPersona)value;

            return persona;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
