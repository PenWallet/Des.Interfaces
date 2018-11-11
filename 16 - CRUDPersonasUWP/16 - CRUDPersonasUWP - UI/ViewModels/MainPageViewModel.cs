using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using BL.Listados;

namespace ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Propiedades privadas
        private List<ClsPersona> _listadoPersonas;
        private ClsPersona _personaSeleccionada;
        private List<ClsDepartamento> _listadoDepartamentos;
        #endregion

        #region Propiedades públicas
        public event PropertyChangedEventHandler PropertyChanged;
        public List<ClsPersona> listadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }

            set
            {
                _listadoPersonas = value;
            }
        }

        public ClsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }

            set
            {
                _personaSeleccionada = value;
                OnPropertyChanged("personaSeleccionada");
            }
        }

        public List<ClsDepartamento> listadoDepartamentos
        {
            get
            {
                return _listadoDepartamentos;
            }

            set
            {
                _listadoDepartamentos = value;
            }
        }
        #endregion

        #region Constructor por defecto
        public MainPageViewModel()
        {
            //Cargar listado de personas
            listadoPersonas = ClsListadoPersonas_BL.listadoCompletoPersonas_BL();

            //Cargar listado de departamentos
            listadoDepartamentos = clsListadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
        }
        #endregion

        #region "Funciones"
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}