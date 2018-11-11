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
    public class AddPersonViewModel
    {
        #region Propiedades privadas
        private List<ClsDepartamento> _listadoDepartamentos;
        #endregion

        #region Propiedades públicas
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
        public AddPersonViewModel()
        {
            //Cargar listado de departamentos
            listadoDepartamentos = clsListadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
        }
        #endregion
    }
}