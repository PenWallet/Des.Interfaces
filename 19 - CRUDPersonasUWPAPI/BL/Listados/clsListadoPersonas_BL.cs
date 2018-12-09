﻿using System.Collections.Generic;
using Entidades;
using DAL.Listados;
using System.Threading.Tasks;

namespace BL.Listados
{
    public class ClsListadoPersonas_BL
    {
        /// <summary>
        /// Función que devuelve la lista tras pasar las reglas necesarias
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        static public Task<List<ClsPersona>> listadoCompletoPersonas_BL()
        {
            var lista = ClsListadoPersonas_DAL.obtenerListadoPersonas_DAL();

            return lista;
        }
    }
}
