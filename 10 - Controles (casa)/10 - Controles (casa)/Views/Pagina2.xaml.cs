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
using Windows.UI;
using _10___Controles__casa_.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _10___Controles__casa_.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pagina2 : Page
    {
        public Pagina2()
        {
            this.InitializeComponent();
            rectangulo.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }

        /// <summary>
        /// Se ejecuta cada vez que se cambia cualquiera de los sliders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //Se coge los valores de los sliders y se le cambia el color al rectángulo
            rectangulo.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)slRed.Value, (byte)slGreen.Value, (byte)slBlue.Value));
        }

        private void VolverAtras(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
