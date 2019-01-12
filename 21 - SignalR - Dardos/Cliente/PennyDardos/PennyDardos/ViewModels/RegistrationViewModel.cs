using PennyDardos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyDardos.ViewModels
{
    public class RegistrationViewModel : clsVMBase
    {
        public RegistrationViewModel()
        {
            _colors = new List<ColorVM>();
            selectedColor = null;
        }

        #region Propiedades privadas
        private List<ColorVM> _colors;
        #endregion

        #region Propiedades públicas
        public ColorVM selectedColor { get; set; }
        public List<ColorVM> colors
        {
            get
            {
                return _colors;
            }
            
            set
            {
                _colors = value;
                NotifyPropertyChanged("colors");
            }
        }
        #endregion
    }
}
