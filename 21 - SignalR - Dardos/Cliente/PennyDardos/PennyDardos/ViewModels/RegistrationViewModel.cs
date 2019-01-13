using PennyDardos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace PennyDardos.ViewModels
{
    public class RegistrationViewModel : clsVMBase
    {
        public RegistrationViewModel()
        {
            _colors = new List<ColorVM>();
            selectedColor = null;
            listadoCursores = generarListadoCursores();
            selectedCursor = null;
        }

        #region Propiedades privadas
        private List<ColorVM> _colors;        
        #endregion

        #region Propiedades públicas
        public ColorVM selectedColor { get; set; }
        public List<CustomCursor> listadoCursores { get; set; }
        public CustomCursor selectedCursor { get; set; }
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

        #region Aonde meto esto
        private List<CustomCursor> generarListadoCursores()
        {
            List<CustomCursor> listado = new List<CustomCursor>();
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Plátano", "banana"));
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Dardo", "dart"));
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Fukiya", "fukiya"));
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Cuchillo", "knife"));
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Bazooka", "launcher"));
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Maza", "morningstar"));
            listado.Add(new CustomCursor(new CoreCursor(CoreCursorType.Custom, 102), "Espada", "sword"));

            return listado;
        }
        #endregion
    }
}
