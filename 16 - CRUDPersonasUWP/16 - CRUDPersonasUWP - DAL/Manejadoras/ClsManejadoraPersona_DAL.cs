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
    public class ClsManejadoraPersona_DAL
    {
        public static ClsPersona PersonaPorID_DAL(int id)
        {
            //Variables
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            SqlParameter param;
            clsMyConnection gestConexion = new clsMyConnection();
            ClsPersona p1 = null;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Personas WHERE IDPersona = @id";

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
                    p1 = new ClsPersona();
                    //Definir los atributos del objeto
                    p1.idPersona = (int)miLector["IDPersona"];
                    p1.nombre = (string)miLector["nombrePersona"];
                    p1.apellidos = (string)miLector["apellidosPersona"];
                    p1.fechaNac = (DateTime)miLector["fechaNacimiento"];
                    p1.telefono = (string)miLector["telefono"];
                    p1.direccion = (string)miLector["direccion"];
                    p1.idDepartamento = (int)miLector["IDDepartamento"];
                }


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return p1;
        }

        public static int BorrarPorID_DAL(int id)
        {
            //Variables
            SqlConnection conexion = null;
            SqlCommand miComando = new SqlCommand();
            SqlParameter param;
            clsMyConnection gestConexion = new clsMyConnection();
            int filas = 0;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "DELETE FROM Personas WHERE IDPersona = @id";

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
                filas = miComando.ExecuteNonQuery();


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
            }

            return filas;
        }

        public static int CrearPersona_DAL(ClsPersona p1)
        {
            //Variables
            SqlConnection conexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            int filas = 0;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "INSERT INTO Personas(nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento)" +
                    "VALUES (@nombre, @apellidos, @fecha, @telefono, @direccion, @idDep)";

                //Creamos los parámetros
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = p1.nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = p1.apellidos;
                miComando.Parameters.Add("@fecha", System.Data.SqlDbType.Date).Value = p1.fechaNac;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = p1.telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = p1.direccion;
                miComando.Parameters.Add("@idDep", System.Data.SqlDbType.Int).Value = p1.idDepartamento;

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                filas = miComando.ExecuteNonQuery();


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
            }

            return filas;
        }

        public static int ActualizarPersona_DAL(ClsPersona p1)
        {
            //Variables
            SqlConnection conexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            int filas = 0;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "UPDATE Personas SET nombrePersona = @nombre, apellidosPersona = @apellidos, fechaNacimiento = @fecha, telefono = @telefono, direccion = @direccion, IDDepartamento = @idDep WHERE IDPersona = @id";

                //Creamos los parámetros
                miComando.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = p1.idPersona;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = p1.nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = p1.apellidos;
                miComando.Parameters.Add("@fecha", System.Data.SqlDbType.Date).Value = p1.fechaNac;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = p1.telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = p1.direccion;
                miComando.Parameters.Add("@idDep", System.Data.SqlDbType.Int).Value = p1.idDepartamento;

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                filas = miComando.ExecuteNonQuery();


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
            }

            return filas;
        }
    }
}
