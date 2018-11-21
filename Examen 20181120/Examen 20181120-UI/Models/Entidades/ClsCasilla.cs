using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Entidades
{
    /// <summary>
    /// Clase Casilla que contiene el estado en el que se encuentra y la ruta de la imagen que le corresponde
    /// Atributos:
    ///     - esBomba: Boolean, consultable, modificable
    ///     - estaPresionada: Boolean, consultable, modificable
    ///     - rutaImagen: String, consultable, modificable (Depende de si es una bomba o no, y de si está presionada o no)
    /// </summary>
    public class ClsCasilla : clsVMBase
    {
        #region Propiedades privadas
        private string _rutaImagen;
        private string _borderColor;
        #endregion

        #region Propiedades públicas
        public bool esBomba { get; set; }
        public bool estaPresionada { get; set; }
        public string rutaImagen
        {
            get
            {
                return _rutaImagen;
            }

            set
            {
                _rutaImagen = value;
                NotifyPropertyChanged("rutaImagen");
            }
        }

        public string borderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;
                NotifyPropertyChanged("borderColor");
            }
        }
        #endregion

        #region Constructores
        public ClsCasilla()
        {
            this.esBomba = false;
            this.estaPresionada = false;
            this.rutaImagen = "../Assets/Imagenes/presionar.png";
            this.borderColor = "SkyBlue";
        }

        /// <summary>
        /// Constructor que establece esBomba según los parámetros, y pone por defecto estaPresionada, rutaImagen y borderColor
        /// </summary>
        /// <param name="esBomba">Establece si la casilla es una bomba o no</param>
        public ClsCasilla(bool esBomba)
        {
            this.esBomba = esBomba;
            this.estaPresionada = false;
            this.rutaImagen = "../Assets/Imagenes/presionar.png";
            this.borderColor = "SkyBlue";
        }
        #endregion
    }
}
