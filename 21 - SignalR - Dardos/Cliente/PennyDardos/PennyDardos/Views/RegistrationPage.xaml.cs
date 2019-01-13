using Microsoft.AspNet.SignalR.Client;
using PennyDardos.Models;
using PennyDardos.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PennyDardos.Views
{
    public sealed partial class RegistrationPage : Page
    {
        public HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        private RegistrationViewModel vm;
        private string nickname;

        public RegistrationPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Custom, 102);
            vm = new RegistrationViewModel();
            this.DataContext = vm;

            #region SignalR
            conn = new HubConnection("https://pennydardos.azurewebsites.net/");
            proxy = conn.CreateHubProxy("LoginHub");
            conn.Start();

            proxy.On<bool>("checkUsernameAvailability", checkUsernameAvailability);
            proxy.On<List<Color>>("updateColors", updateColors);
            #endregion
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            nickname = txtNick.Text;

            if(nickname == "")
            {
                txtError.Text = "¡Debes introducir un nickname!";
                txtError.Visibility = Visibility.Visible;
            }
            else if(nickname.Length < 4)
            {
                txtError.Text = "¡Tu nickname debe tener más de 3 caracteres!";
                txtError.Visibility = Visibility.Visible;
            }
            else if(vm.selectedColor == null)
            {
                txtError.Text = "¡Debes elegir un color!";
                txtError.Visibility = Visibility.Visible;
            }
            else
            {
                proxy.Invoke("checkUsernameAvailability", nickname);
            }
        }

        private async void checkUsernameAvailability(bool isAvailable)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                if (isAvailable)
                {
                    txtError.Text = "";
                    txtError.Visibility = Visibility.Collapsed;

                    conn.Stop();
                    JugadorVM jugador = new JugadorVM(nickname, 0, vm.selectedColor.color);
                    MainPageViewModel mainVM = new MainPageViewModel(jugador);
                    this.Frame.Navigate(typeof(MainPage), mainVM);
                }
                else
                {
                    txtError.Text = "¡Este nickname ya está cogido!";
                    txtError.Visibility = Visibility.Visible;
                }
            }
            );
        }

        private async void updateColors(List<Color> listadoColores)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                List<ColorVM> listadoFinal = new List<ColorVM>();
                foreach (Color color in listadoColores)
                {
                    listadoFinal.Add(new ColorVM(color.color, color.isAvailable));
                }
                vm.colors = listadoFinal;
            }
            );
        }

        private void gridColorPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if(vm.colors == null || vm.colors.Count == 0)
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Wait, 10);
        }

        private void gridColorPointerExited(object sender, PointerRoutedEventArgs e)
        {
            //Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 0);
            Window.Current.CoreWindow.PointerCursor = vm.selectedCursor == null ? new CoreCursor(CoreCursorType.Arrow, 0) : vm.selectedCursor.cursor;
        }

        private void selectCursor(object sender, ItemClickEventArgs e)
        {
            CustomCursor customCursor = e.ClickedItem as CustomCursor;
            vm.selectedCursor = customCursor;
            Window.Current.CoreWindow.PointerCursor = customCursor.cursor;
        }
    }
}
