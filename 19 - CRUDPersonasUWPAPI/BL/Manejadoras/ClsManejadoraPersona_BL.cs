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
        public static Task<ClsPersona> PersonaPorID_BL(int id)
        {
            var p1 = ClsManejadoraPersona_DAL.PersonaPorID_DAL(id);

            return p1;
        }

        public static async Task<bool> BorrarPorID_BL(int id)
        {
            bool guardado = await ClsManejadoraPersona_DAL.BorrarPorID_DAL(id);

            return guardado;
        }

        public static async Task<bool> CrearPersona_BL(ClsPersona p1)
        {
            bool guardado = await ClsManejadoraPersona_DAL.CrearPersona_DAL(p1);

            return guardado;
        }

        public static async Task<bool> ActualizarPersona_BL(ClsPersona p1)
        {
            bool guardado = await ClsManejadoraPersona_DAL.ActualizarPersona_DAL(p1);

            return guardado;
        }
    }
}
