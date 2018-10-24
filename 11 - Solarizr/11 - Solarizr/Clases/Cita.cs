using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Clases
{

    /**
     * Clase Cita:
     * 
     *      - Atributos básicos:
     *          - IDCliente (int, consultable y modificable)
     *          - Nombre (string, consultable y modificable)
     *          - Apellidos (string, consultable y modificable)
     *          - Direccion (String, consultable y modificable)
     *          - Fecha (DateTime, consultable y modificable)
     *          - Fotos: (Lista de imágenes, consultable y modificable)
     *          - Comentario (String, consultable y modificable)
     *          - Finalizada (Boolean, consultable y modificable)
     *          
     *      - Restricciones:
     *          - Por ahora, no.
     *          
     *      - Métodos añadidos:
     *          - :(
     * 
     * 
     */
    public class Cita
    {

        #region atributos
        public int IDCliente { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public DateTime fecha { get; set; }
        public List<StorageFile> fotos { get; set; }
        public string comentario { get; set; }
        public bool finalizada { get; set; }
        #endregion
        
    }
}

/** 
 * 
 *      Método asíncrono para introducir una foto a través del explorador de ficheros, quizás sea necesario más adelante.
 * 
 *      public async void abrirArchivo()
        {
            var openPicker = new FileOpenPicker();  // Nos permite abrir el explorador de ficheros
            fotos.Add(await openPicker.PickSingleFileAsync()); //Añade la foto elegida a nuestra lista de fotos desde el explorador.
        }
 * 
 */
