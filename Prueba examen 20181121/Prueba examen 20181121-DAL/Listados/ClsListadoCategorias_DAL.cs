using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL.Listados
{
    public static class ClsListadoCategorias_DAL
    {
        public static List<ClsCategoria> listadoCompletoCategorias_DAL()
        {
            List<ClsCategoria> lista = new List<ClsCategoria>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsCategoria categoria;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Categorias";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        categoria = new ClsCategoria();
                        //Definir los atributos del objeto
                        categoria.ID = (int)miLector["idCategoria"];
                        categoria.nombre = (string)miLector["nombreCategoria"];

                        //Añadir objeto a la lista
                        lista.Add(categoria);
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
