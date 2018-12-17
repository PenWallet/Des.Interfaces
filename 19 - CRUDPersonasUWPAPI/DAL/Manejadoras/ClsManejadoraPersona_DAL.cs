using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Listados;
using Entidades;
using Newtonsoft.Json;
using DAL.Conexion;
using System.Net.Http;

namespace DAL.Manejadoras
{
    public class ClsManejadoraPersona_DAL
    {
        public static async Task<ClsPersona> PersonaPorID_DAL(int id)
        {
            var persona = new ClsPersona();
            HttpClient client = new HttpClient();
            Uri uriCompleta = new Uri($"{ClsUriBase.uri}personas/{id}");

            //Cogemos las cabeceras por defecto 
            var headers = client.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await client.GetAsync(uriCompleta);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                persona = JsonConvert.DeserializeObject<ClsPersona>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return persona;
        }

        public async static Task<bool> BorrarPorID_DAL(int id)
        {
            var persona = new ClsPersona();
            bool borrado = false;
            HttpClient client = new HttpClient();
            Uri uriCompleta = new Uri($"{ClsUriBase.uri}personas/{id}");

            //Cogemos las cabeceras por defecto 
            var headers = client.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            //Send the DELETE request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the DELETE request
                httpResponse = await client.DeleteAsync(uriCompleta);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponseBody == "true")
                    borrado = true;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return borrado;
        }

        public static async Task<bool> CrearPersona_DAL(ClsPersona p1)
        {
            var persona = new ClsPersona();
            bool guardado = false;
            HttpClient client = new HttpClient();
            Uri uriCompleta = new Uri($"{ClsUriBase.uri}personas/");

            //Cogemos las cabeceras por defecto 
            var headers = client.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            
            
            //Send the POST request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                var jsonText = JsonConvert.SerializeObject(p1);
                var contenido = new StringContent(jsonText, System.Text.Encoding.UTF8, "application/json");

                //Send the POST request
                httpResponse = await client.PostAsync(uriCompleta, contenido);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponseBody == "true")
                    guardado = true;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return guardado;
        }

        public static async Task<bool> ActualizarPersona_DAL(ClsPersona p1)
        {
            var persona = new ClsPersona();
            bool guardado = false;
            HttpClient client = new HttpClient();
            Uri uriCompleta = new Uri($"{ClsUriBase.uri}personas/");

            //Cogemos las cabeceras por defecto 
            var headers = client.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }



            //Send the POST request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                var jsonText = JsonConvert.SerializeObject(p1);
                var contenido = new StringContent(jsonText, System.Text.Encoding.UTF8, "application/json");

                //Send the POST request
                httpResponse = await client.PutAsync(uriCompleta, contenido);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponseBody == "true")
                    guardado = true;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return guardado;
        }
    }
}
