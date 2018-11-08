using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Listados;
using Entidades;

namespace DAL.Manejadoras
{
    public class ClsManejadoraDepartamento_BL
    {
        public static ClsDepartamento DepartamentoPorID_DAL(int id)
        {
            ClsDepartamento d1 = null;

            d1 = ClsManejadoraDepartamento_DAL.DepartamentoPorID_DAL(id);

            return d1;
        }
    }
}
