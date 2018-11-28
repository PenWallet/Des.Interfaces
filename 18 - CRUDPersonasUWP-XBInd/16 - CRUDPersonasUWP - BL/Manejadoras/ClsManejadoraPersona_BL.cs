using DAL.Manejadoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Manejadoras
{
    public class ClsManejadoraPersona_BL
    {
        public static ClsPersona PersonaPorID_BL(int id)
        {
            ClsPersona p1 = ClsManejadoraPersona_DAL.PersonaPorID_DAL(id);

            return p1;
        }

        public static int BorrarPorID_BL(int id)
        {
            int filas = ClsManejadoraPersona_DAL.BorrarPorID_DAL(id);

            return filas;
        }

        public static int CrearPersona_BL(ClsPersona p1)
        {
            int filas = ClsManejadoraPersona_DAL.CrearPersona_DAL(p1);

            return filas;
        }

        public static int ActualizarPersona_BL(ClsPersona p1)
        {
            int filas = ClsManejadoraPersona_DAL.ActualizarPersona_DAL(p1);

            return filas;
        }
    }
}
