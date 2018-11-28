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
    public class ClsListadoPersonas_DAL
    {
        /// <summary>
        /// Función que devuelve un List de ClsPersona
        /// 
        /// Devuelve una lista vacía si no hay datos en la base de datos; en caso contrario, lista con las personas
        /// de la base de datos
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public static List<ClsPersona> listadoCompletoPersonas()
        {
            //Variables
            List<ClsPersona> lista = new List<ClsPersona>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsPersona p1;

            
            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Personas";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();
                
                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if(miLector.HasRows)
                {
                    while(miLector.Read())
                    {
                        p1 = new ClsPersona();
                        //Definir los atributos del objeto
                        p1.idPersona = (int)miLector["IDPersona"];
                        p1.nombre = (string)miLector["nombrePersona"];
                        p1.apellidos = (string)miLector["apellidosPersona"];
                        p1.fechaNac = (DateTime)miLector["fechaNacimiento"];
                        p1.telefono = (string)miLector["telefono"];
                        p1.direccion = (string)miLector["direccion"];
                        p1.idDepartamento = (int)miLector["IDDepartamento"];

                        //Añadir objeto a la lista
                        lista.Add(p1);
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
