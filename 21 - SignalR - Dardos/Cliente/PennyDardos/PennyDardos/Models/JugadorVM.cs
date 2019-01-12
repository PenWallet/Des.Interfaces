using PennyDardos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyDardos.Models
{
    public class JugadorVM : clsVMBase
    {
        private int _puntuacion;
        public string nombre { get; set; }
        public string color { get; set; }
        public int puntuacion
        {
            get
            {
                return _puntuacion;
            }

            set
            {
                _puntuacion = value;
                NotifyPropertyChanged("puntuacion");
            }
        }

        public JugadorVM()
        {
            this.nombre = "";
            this._puntuacion = 0;
            this.color = "";
        }

        public JugadorVM(string nombre, int puntuacion, string color)
        {
            this.nombre = nombre;
            this._puntuacion = puntuacion;
            this.color = color;
        }
    }
}
