using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Listados;

namespace BL.Listados
{
    public static class ClsListadoCategorias_BL
    {
        public static List<ClsCategoria> listadoCompletoCategorias_BL()
        {
            List<ClsCategoria> lista = ClsListadoCategorias_DAL.listadoCompletoCategorias_DAL();

            return lista;
        }
    }
}
