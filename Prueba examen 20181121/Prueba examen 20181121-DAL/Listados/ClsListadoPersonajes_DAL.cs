using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL.Listados
{
    public static class ClsListadoPersonajes_DAL
    {
        /// <summary>
        /// Devuelve un listado completo de todos los personajes del juego
        /// </summary>
        /// <returns>List<ClsCampeon></returns>
        public static List<ClsCampeon> listadoCompletoPersonajes_DAL()
        {
            List<ClsCampeon> lista = new List<ClsCampeon>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsCampeon campeon;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Personajes";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        campeon = new ClsCampeon();
                        //Definir los atributos del objeto
                        campeon.ID = (int)miLector["idPersonaje"];
                        campeon.nombre = (string)miLector["nombre"];
                        campeon.alias = (string)miLector["alias"];
                        campeon.vida = (double)miLector["vida"];
                        campeon.regeneracion = (double)miLector["regeneracion"];
                        campeon.danno = (double)miLector["danno"];
                        campeon.armadura = (double)miLector["armadura"];
                        campeon.velAtaque = (double)miLector["velAtaque"];
                        campeon.resistencia = (double)miLector["resistencia"];
                        campeon.velMovimiento = (double)miLector["velMovimiento"];
                        campeon.IDCategoria = (int)miLector["idCategoria"];
                        campeon.rutaImagen = $"../Assets/Imagenes/{campeon.nombre}.png";

                        //Añadir objeto a la lista
                        lista.Add(campeon);
                    }
                }


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return lista;
        }

        /// <summary>
        /// Devuelve un listado de personajes dependiendo de la categoría a la que pertenezcan
        /// </summary>
        /// <param name="IDCategoria">ID de la categoría a la que pertenecen</param>
        /// <returns>List<ClsCampeon></returns>
        public static List<ClsCampeon> listadoPersonajesPorCategoria_DAL(int IDCategoria)
        {
            List<ClsCampeon> lista = new List<ClsCampeon>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsCampeon campeon;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = $"SELECT * FROM Personajes WHERE idCategoria = {IDCategoria}";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        campeon = new ClsCampeon();
                        //Definir los atributos del objeto
                        campeon.ID = (int)miLector["idPersonaje"];
                        campeon.nombre = (string)miLector["nombre"];
                        campeon.alias = (string)miLector["alias"];
                        campeon.vida = (double)miLector["vida"];
                        campeon.regeneracion = (double)miLector["regeneracion"];
                        campeon.danno = (double)miLector["danno"];
                        campeon.armadura = (double)miLector["armadura"];
                        campeon.velAtaque = (double)miLector["velAtaque"];
                        campeon.resistencia = (double)miLector["resistencia"];
                        campeon.velMovimiento = (double)miLector["velMovimiento"];
                        campeon.IDCategoria = (int)miLector["idCategoria"];
                        campeon.rutaImagen = $"../Assets/Imagenes/{campeon.nombre}.png";

                        //Añadir objeto a la lista
                        lista.Add(campeon);
                    }
                }


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return lista;
        }
    }
}
