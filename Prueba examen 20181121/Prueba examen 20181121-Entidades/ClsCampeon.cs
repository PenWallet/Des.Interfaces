using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Campeón que incluye todos los atributos de los campeones del LoL
    /// Atributos:
    ///     ID: Int, consultable, modificable
    ///     Nombre: String, consultable, modificable
    ///     Alias: String, consultable, modificable
    ///     Vida: Double, consultable, modificable
    ///     Regeneración: Double, consultable, modificable
    ///     Danno: Double, consultable, modificable
    ///     Armadura: Double, consultable, modificable
    ///     VelAtaque: Double, consultable, modificable
    ///     Resistencia: Double, consultable, modificable
    ///     VelMovimiento: Double, consultable, modificable
    ///     IDCategoria: Int, consultable, modificable
    /// </summary>
    public class ClsCampeon
    {
        #region Atributos
        public int ID { get; set; }
        public string nombre { get; set; }
        public string alias { get; set; }
        public double vida { get; set; }
        public double regeneracion { get; set; }
        public double danno { get; set; }
        public double armadura { get; set; }
        public double velAtaque { get; set; }
        public double resistencia { get; set; }
        public double velMovimiento { get; set; }
        public int IDCategoria { get; set; }
        #endregion

        #region Constructores
        public ClsCampeon()
        {
            this.ID = 0;
            this.nombre = "";
            this.alias = "";
            this.vida = 0;
            this.regeneracion = 0;
            this.danno = 0;
            this.armadura = 0;
            this.velAtaque = 0;
            this.resistencia = 0;
            this.velMovimiento = 0;
            this.IDCategoria = 0;
        }

        public ClsCampeon(int ID, string nombre, string alias, double vida, double regeneracion,
                            double danno, double armadura, double velAtaque, double resistencia,
                            double velMovimiento, int IDCategoria)
        {
            this.ID = 0;
            this.nombre = nombre;
            this.alias = alias;
            this.vida = vida;
            this.regeneracion = regeneracion;
            this.danno = danno;
            this.armadura = armadura;
            this.velAtaque = velAtaque;
            this.resistencia = resistencia;
            this.velMovimiento = velMovimiento;
            this.IDCategoria = IDCategoria;
        }
        #endregion
    }
}
