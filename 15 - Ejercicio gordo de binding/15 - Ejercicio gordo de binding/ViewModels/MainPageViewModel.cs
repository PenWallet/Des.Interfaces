using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entidades;
using Models.Manejadoras;

namespace _15___Ejercicio_gordo_de_binding.ViewModels
{
    public class MainPageViewModel
    {
        #region Propiedades privadas
        private List<ClsPersona> _listadoPersonas;
        private ClsPersona _personaSeleccionada;
        private List<ClsDepartamento> _listadoDepartamentos;
        #endregion

        #region Propiedades públicas
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
            listadoPersonas = ClsListadoPersonas.rellenar();
        }
        #endregion
    }
}