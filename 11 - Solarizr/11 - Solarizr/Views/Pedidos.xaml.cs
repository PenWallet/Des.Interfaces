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
using Clases;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

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
                direccion = "Sevilla, Calle Regina"
            };

            ContentList.Add(cita1);
            contenidoLista cita2 = new contenidoLista()
            {
                nombre = "Sefuran-kun",
                apellidos = "Flowered Flowers",
                fecha = "21/10/2018",
                direccion = "Sevilla, Calle Oso Panda"
            };
            ContentList.Add(cita2);
            ContentList.Add(cita1);

            lsvCitas.DataContext = ContentList;
        }

        private async void launchMaps(string direccion)
        {
            // Centro en la calle del cliente
            var calle = new Uri(@"bingmaps:?q="+direccion);

            // Launch the Windows Maps app
            var launcherOptions = new Windows.System.LauncherOptions();
            launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
            var success = await Windows.System.Launcher.LaunchUriAsync(calle, launcherOptions);
        }

        private BasicGeoposition addressToCoordinates(string direccion)
        {
            //https://docs.microsoft.com/en-us/windows/uwp/maps-and-location/geocoding

            //Esto es una pista de dónde empezar a buscar la latitud y la longitud de la dirección del cliente
            BasicGeoposition queryHint = new BasicGeoposition();
            queryHint.Latitude = 47.643;
            queryHint.Longitude = -122.131;
            Geopoint hintPoint = new Geopoint(queryHint);

            //Nos devuelve las coordenadas
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(direccion, hintPoint, 1);

            //Esto es el BasicGeoposition con las coordenadas
            BasicGeoposition posicion = result.Locations[0].Point.Position;

            return posicion;
        }

        private void mapa_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            launchMaps("prueba");
        }

        private void lsvCitas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cita cita = (sender as Grid).DataContext as Cita;

            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 37.3914105, Longitude = -5.9591776 };
            Geopoint cityCenter = new Geopoint(cityPosition);


            //Sefran hace lo de las fotos
        }
    }
}
