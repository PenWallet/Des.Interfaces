using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _11___Solarizr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pedidos : Page
    {
        public class contenidoLista
        {
            public string fecha { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string direccion { get; set; }
        }

        public List<contenidoLista> ContentList = new List<contenidoLista>();

        public Pedidos()
        {
            this.InitializeComponent();

            contenidoLista cita1 = new contenidoLista()
            {
                nombre = "Oscar",
                apellidos = "Funes Trigo",
                fecha = "23/10/2018",
                direccion = "c/Falsa"
            };

            ContentList.Add(cita1);
            contenidoLista cita2 = new contenidoLista()
            {
                nombre = "Sefuran-kun",
                apellidos = "Flowered Flowers",
                fecha = "21/10/2018",
                direccion = "c/NoHetero"
            };
            ContentList.Add(cita2);
            ContentList.Add(cita1);

            lsvCitas.DataContext = ContentList;
        }
    }
}
