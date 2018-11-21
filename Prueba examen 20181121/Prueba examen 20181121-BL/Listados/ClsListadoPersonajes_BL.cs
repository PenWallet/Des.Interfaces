using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Listados;
using Entidades;

namespace BL.Listados
{
    public static class ClsListadoPersonajes_BL
    {
        /// <summary>
        /// Devuelve un listado completo de todos los personajes del juego
        /// </summary>
        /// <returns>List<ClsCampeon></returns>
        public static List<ClsCampeon> listadoCompletoPersonajes_DAL()
        {
            List<ClsCampeon> lista = ClsListadoPersonajes_DAL.listadoCompletoPersonajes_DAL();

            return lista;
        }


        /// <summary>
        /// Devuelve un listado de personajes dependiendo de la categoría a la que pertenezcan
        /// </summary>
        /// <param name="IDCategoria">ID de la categoría a la que pertenecen</param>
        /// <returns>List<ClsCampeon></returns>
        public static List<ClsCampeon> listadoPersonajesPorCategoria_DAL(int IDCategoria)
        {
            List<ClsCampeon> lista = ClsListadoPersonajes_DAL.listadoPersonajesPorCategoria_DAL(IDCategoria);

            return lista;
        }
    }
}
