using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyDardos.Models
{
    public class Jugador
    {
        public string nombre { get; set; }
        public int puntuacion { get; set; }
        public string color { get; set; }

        public Jugador()
        {
            this.nombre = "";
            this.puntuacion = 0;
            this.color = "";
        }

        public Jugador(string nombre, int puntuacion, string color)
        {
            this.nombre = nombre;
            this.puntuacion = puntuacion;
            this.color = color;
        }
    }
}
