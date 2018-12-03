using System.Collections.Generic;
using Entidades;
using DAL.Listados;

namespace BL.Listados
{
    public class clsListadoDepartamentos_BL
    {
        /// <summary>
        /// Función que devuelve la lista tras pasar las reglas necesarias
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        static public List<ClsDepartamento> listadoCompletoDepartamentos_BL()
        {
            List<ClsDepartamento> lista = ClsListadoDepartamentos_DAL.listadoCompletoDepartamentos();

            return lista;
        }
    }
}
