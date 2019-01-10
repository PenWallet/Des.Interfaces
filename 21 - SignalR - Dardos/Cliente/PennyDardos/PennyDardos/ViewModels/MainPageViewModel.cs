using PennyDardos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PennyDardos.ViewModels;

namespace PennyDardos.ViewModels
{
    public class MainPageViewModel : clsVMBase
    {
        public MainPageViewModel()
        {
            _casillas = new List<CasillaVM>();
            _puntuacionGlobal = 0;
            _puntuacionPersonal = 0;
            _jugadoresEnLinea = 0;
        }

        #region Propiedades privadas
        private List<CasillaVM> _casillas;
        private int _puntuacionGlobal;
        private int _puntuacionPersonal;
        private int _jugadoresEnLinea;
        #endregion

        #region Propiedades públicas
        public List<CasillaVM> casillas
        {
            get
            {
                return _casillas;
            }

            set
            {
                _casillas = value;
                NotifyPropertyChanged("casillas");
            }
        }

        public int puntuacionGlobal
        {
            get
            {
                return _puntuacionGlobal;
            }

            set
            {
                _puntuacionGlobal = value;
                NotifyPropertyChanged("puntuacionGlobal");
            }
        }

        public int puntuacionPersonal
        {
            get
            {
                return _puntuacionPersonal;
            }

            set
            {
                _puntuacionPersonal = value;
                NotifyPropertyChanged("puntuacionPersonal");
            }
        }

        public int jugadoresEnLinea
        {
            get
            {
                return _jugadoresEnLinea;
            }

            set
            {
                _jugadoresEnLinea = value;
                NotifyPropertyChanged("jugadoresEnLinea");
            }
        }
        #endregion
    }
}
