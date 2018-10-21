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
using Windows.UI.Popups;
using _10___Controles__casa_.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _10___Controles__casa_.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pagina3 : Page
    {
        public Pagina3()
        {
            this.InitializeComponent();
        }

        private void VolverAtras(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void elegirVideo(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                switch(content.ToString())
                {
                    case "Golf":
                        reproductor.Source = new Uri("ms-appx:///Assets/Samples/sample1.avi");
                        break;

                    case "Shot Putt":
                        reproductor.Source = new Uri("ms-appx:///Assets/Samples/sample2.avi");
                        break;

                    case "Casco Slow-Mo":
                        reproductor.Source = new Uri("ms-appx:///Assets/Samples/sample3.avi");
                        break;

                    case "Salto de caballo Slow-Mo":
                        reproductor.Source = new Uri("ms-appx:///Assets/Samples/sample4.avi");
                        break;
                }
                
            }
        }

        private async void rating(object sender, RoutedEventArgs e)
        {
            var dialog = new ContentDialog()
            {
                Title = "Por favor, vota cuánto te ha gustado el vídeo",
                RequestedTheme = ElementTheme.Dark
            };

            var panel = new StackPanel();

            panel.Children.Add(new RatingControl{});

            dialog.Content = panel;

            dialog.PrimaryButtonText = "Hecho";
            dialog.SecondaryButtonText = "Cancelar";

            await dialog.ShowAsync();
        }
    }
}
