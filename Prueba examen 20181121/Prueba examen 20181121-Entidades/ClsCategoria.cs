using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Categoría que incluye el ID y el nombre de cada categoría de la base de datos del LoL
    /// Atributos:
    ///     ID: Int, consultable, modificable
    ///     Nombre: String, consultable, modificable
    /// </summary>
    public class ClsCategoria
    {
        #region Atributos
        public int ID { get; set; }
        public string nombre { get; set; }
        #endregion

        #region Constructores
        public ClsCategoria()
        {
            this.ID = 0;
            this.nombre = "";
        }
        public ClsCategoria(int ID, string nombre)
        {
            this.ID = ID;
            this.nombre = nombre;
        }
        #endregion
    }
}
