using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Listados;

namespace DAL.Listados
{
    public class ClsListadoDepartamentos_DAL
    {
        /// <summary>
        /// Función que devuelve un List de ClsPersona
        /// 
        /// Devuelve una lista vacía si no hay datos en la base de datos; en caso contrario, lista con las personas
        /// de la base de datos
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public static List<ClsDepartamento> listadoCompletoDepartamentos()
        {
            //Variables
            List<ClsDepartamento> lista = new List<ClsDepartamento>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsDepartamento d1;

            
            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Departamentos";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();
                
                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if(miLector.HasRows)
                {
                    while(miLector.Read())
                    {
                        d1 = new ClsDepartamento();
                        //Definir los atributos del objeto
                        d1.idDepartamento = (int)miLector["IDDepartamento"];
                        d1.nombreDepartamento = (string)miLector["nombreDepartamento"];

                        //Añadir objeto a la lista
                        lista.Add(d1);
                    }
                }
                
            
            } catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return lista;
        }
    }
}
