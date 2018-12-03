using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class ClsDepartamento
    {
        #region Constructor por defecto
        public ClsDepartamento()
        {

        }
        #endregion

        #region Constructor con parámetros
        public ClsDepartamento(int idDepartamento, string nombreDepartamento)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
        }
        #endregion

        #region "Atributos"
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        #endregion
    }
}