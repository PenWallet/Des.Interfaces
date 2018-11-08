using System.Collections.Generic;
using Entidades;
using DAL.Listados;

namespace BL.Listados
{
    public class ClsListadoPersonas_BL
    {
        /// <summary>
        /// Función que devuelve la lista tras pasar las reglas necesarias
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        static public List<ClsPersona> listadoCompletoPersonas_BL()
        {
            List<ClsPersona> lista = ClsListadoPersonas_DAL.listadoCompletoPersonas();

            return lista;
        }
    }
}
