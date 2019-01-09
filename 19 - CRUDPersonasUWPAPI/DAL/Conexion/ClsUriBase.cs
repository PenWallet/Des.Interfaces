using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion
{
    public class ClsUriBase
    {
        private static readonly string _uri = "https://apipennypersonas2.azurewebsites.net/api/";

        public static string uri
        {
            get
            {
                return _uri;
            }
        }
    }
}
