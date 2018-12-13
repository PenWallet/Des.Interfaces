using System.Collections.Generic;
using Entidades;
using DAL.Listados;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BL.Listados
{
    public class ClsListadoPersonas_BL
    {
        /// <summary>
        /// Función que devuelve la lista tras pasar las reglas necesarias
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public static async Task<ObservableCollection<ClsPersona>> listadoCompletoPersonas_BL()
        {
            ObservableCollection<ClsPersona> lista = new ObservableCollection<ClsPersona>(await ClsListadoPersonas_DAL.obtenerListadoPersonas_DAL());

            return lista;
        }
    }
}
