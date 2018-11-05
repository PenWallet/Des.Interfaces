using System;
using System.Collections.Generic;
using Models.Entidades;

namespace Models.Manejadoras
{
    public static class ClsListadoDepartamentos
    {
        public static List<ClsDepartamento> rellenar()
        {
            List<ClsDepartamento> listaDepartamentos = new List<ClsDepartamento>
            {
                new ClsDepartamento(1, "Informática"),
                new ClsDepartamento(2, "Mantenimiento"),
                new ClsDepartamento(3, "Seguridad"),
                new ClsDepartamento(4, "Administración")
            };

            return listaDepartamentos;
        }
    }
}