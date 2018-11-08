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
    public class ClsManejadoraDepartamento_DAL
    {
        public static ClsDepartamento DepartamentoPorID_DAL(int id)
        {
            //Variables
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            SqlParameter param;
            clsMyConnection gestConexion = new clsMyConnection();
            ClsDepartamento d1 = null;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Departamentos WHERE IDPersona = @id";

                //Creamos los parámetros
                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;
                miComando.Parameters.Add(param);

                //Otra forma:
                //miComando.Parameters.Add("@nombre", System.Data.SqlDbType.Int).Value = id;

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene la fila, si afirmativo, se lee y se obtiene la clase persona
                if (miLector.HasRows)
                {
                    //Leemos la fila
                    miLector.Read();
                    d1 = new ClsDepartamento();
                    //Definir los atributos del objeto
                    d1.idDepartamento = (int)miLector["IDDepartamento"];
                    d1.nombreDepartamento = (string)miLector["nombreDepartamento"];
                }


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return d1;
        }
    }
}
