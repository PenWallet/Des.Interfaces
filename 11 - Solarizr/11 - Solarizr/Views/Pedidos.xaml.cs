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

        public List<Cita> ContentList = new List<Cita>();

        public Pedidos()
        {
            this.InitializeComponent();

            Cita cita1 = new Cita()
            {
                IDCliente = 1,
                nombre = "Oscaru-neko",
                apellidos = "Funes Trigo",
                fecha = new DateTime(2018, 10, 22),
                direccion = "Sevilla, Calle Regina"
            };
            Cita cita2 = new Cita()
            {
                IDCliente = 2,
                nombre = "Sefuran-kun",
                apellidos = "Flowered Flowers",
                fecha = new DateTime(2018, 10, 23),
                direccion = "Sevilla, Calle Oso Panda"
            };
            Cita cita3 = new Cita()
            {
                IDCliente = 3,
                nombre = "Ferunando-sensei",
                apellidos = "Gari-ana Domo",
                fecha = new DateTime(2018, 10, 21),
                direccion = "Madrid, Calle de Cavanilles, 35"
            };
            Cita cita4 = new Cita()
            {
                IDCliente = 4,
                nombre = "Goruje-chan",
                apellidos = "Watashi no apellido",
                fecha = new DateTime(2018, 10, 20),
                direccion = "Japon, Tokyo"
            };
            Cita cita5 = new Cita()
            {
                IDCliente = 5,
                nombre = "Migueru Angeru-sensei",
                apellidos = "Kekkon shita",
                fecha = new DateTime(2018, 10, 23),
                direccion = "Sevilla, Paseo de las Delicias"
            };
            Cita cita6 = new Cita()
            {
                IDCliente = 6,
                nombre = "Nacho",
                apellidos = "Baka-chan",
                fecha = new DateTime(2018, 10, 23),
                direccion = "United States, Washington, Redmond, Microsoft"
            };
            Cita cita7 = new Cita()
            {
                IDCliente = 7,
                nombre = "Asin",
                apellidos = "Kateai Tos",
                fecha = new DateTime(2018, 10, 23),
                direccion = "Area 51"
            };
            ContentList.Add(cita1);
            ContentList.Add(cita2);
            ContentList.Add(cita3);
            ContentList.Add(cita4);
            ContentList.Add(cita5);
            ContentList.Add(cita6);
            ContentList.Add(cita7);

            lsvCitas.DataContext = ContentList;
        }

        private async void lsvCitas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cita = e.ClickedItem as Cita;

            //Esto es una pista de dónde empezar a buscar la latitud y la longitud de la dirección del cliente
            BasicGeoposition pista = new BasicGeoposition();
            pista.Latitude = 40.416775;
            pista.Longitude = -3.703790;
            Geopoint madrid = new Geopoint(pista);

            //Nos devuelve las coordenadas
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(cita.direccion, madrid);

            //Si encuentra la localización
            if (result.Status == MapLocationFinderStatus.Success)
            {
                //Esto es el BasicGeoposition con las coordenadas
                BasicGeoposition posicion = result.Locations[0].Point.Position;
                Geopoint centro = new Geopoint(posicion);

                //Ahora ponemos bien el mapa
                mapa.Center = centro;
                mapa.ZoomLevel = 17;
            }

            //Sefran hace lo de las fotos
        }
    }
}
