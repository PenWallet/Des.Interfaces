using System;
using System.Collections.Generic;
using Models.Entidades;

namespace Models.Manejadoras
{
    public static class ClsListadoPersonas
    {
        public static List<ClsPersona> rellenar()
        {
            List<ClsPersona> listaPersonas = new List<ClsPersona>
            {
                new ClsPersona(1, "Oscar", "Funes", new DateTime(1999, 8, 12), "c/Regina", "342342342", 0),
                new ClsPersona(2, "Sefuran", "Flowered", new DateTime(1812, 6, 10), "c/Falsa", "74518435", 1),
                new ClsPersona(3, "Goruje", "Watashi no apellido", new DateTime(1990, 8, 24), "c/Tokyo", "696969696", 0),
                new ClsPersona(4, "Fernando", "Sensei", new DateTime(1000, 1, 1), "c/PcComponentes", "123456789", 0)
        };

            return listaPersonas;
        }
    }
}