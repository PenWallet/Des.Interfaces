using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class ClsPersona
    {
        #region Constructor por defecto
        public ClsPersona()
        {
            this.idDepartamento = 0;
            this.idPersona = 0;
            this.nombre = "";
            this.apellidos = "";
            this.fechaNac = new DateTimeOffset(new DateTime(1918, 1, 1, 0, 0, 0));
            this.direccion = "";
            this.telefono = "";
        }
        #endregion

        #region Constructor con parámetros
        public ClsPersona(int id, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono, int idDepartamento)
        {
            this.idPersona = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region "Atributos"
        public int idDepartamento { get; set; }
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTimeOffset fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        #endregion


    }
}