using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _15___Ejercicio_gordo_de_binding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel mpVM { get; } = new MainPageViewModel();

        public MainPage()
        {
            this.InitializeComponent();
        }

        /*
        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ClsPersona p1 = (ClsPersona)lvPersonas.SelectedItem;

            if (p1 == null)
            {
                var dialog = new MessageDialog("¡No has elegido ninguna persona!");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog( "¿Deseas borrar a la persona?" );

                dialog.Commands.Add(new UICommand("Sí") { Id = 0 });
                dialog.Commands.Add(new UICommand("No") { Id = 1 });

                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;

                var result = await dialog.ShowAsync();

                if((int)result.Id == 0)
                {
                    int filas = ClsManejadoraPersona_BL.BorrarPorID_BL(p1.idPersona);

                    if (filas == 0)
                        mostrarError();
                    else if (filas == 1)
                    {
                        page.DataContext = new MainPageViewModel();
                        mostrarExito();
                    }
                    else
                        mostrarWTF();
                }
            }
        }

        private async void mostrarError()
        {
            var dialog = new MessageDialog("No se pudo borrar la persona");
            await dialog.ShowAsync();
        }

        private async void mostrarExito()
        {
            var dialog = new MessageDialog("La persona se ha borrado correctamente");
            await dialog.ShowAsync();
        }

        private async void mostrarWTF()
        {
            var dialog = new MessageDialog("Algo ha ido horriblemente mal wtf");
            await dialog.ShowAsync();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }*/
    }
}
