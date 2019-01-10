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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PennyDardos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        public MainPageViewModel mainVM;

        public MainPage()
        {
            this.InitializeComponent();
            mainVM = new MainPageViewModel();
            this.DataContext = mainVM;
            SignalR();
        }

        private void ClickBalloon(object sender, ItemClickEventArgs e)
        {
            CasillaVM casilla = (CasillaVM)e.ClickedItem;
            if (casilla.isBalloon && !casilla.isPopped)
            {
                proxy.Invoke("press", casilla.id);
            }
        }

        #region Funciones Server
        private void SignalR()
        {
            conn = new HubConnection("https://pennydardos.azurewebsites.net/");
            proxy = conn.CreateHubProxy("DardosHub");
            conn.Start();

            proxy.On<int>("updateGlobalScore", updateGlobalScore);
            proxy.On<int>("updateNumberOfPlayers", updateNumberOfPlayers);
            proxy.On<Casilla[]>("loadBalloons", loadBalloons);
            proxy.On("addOnePoint", addOnePoint);
            proxy.On<int>("popBalloon", popBalloon);
        }

        public async void popBalloon(int posBalloon)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                mainVM.casillas[posBalloon].popBalloon();
            }
            );

            /*
            List<CasillaVM> listadoNuevo = mainVM.casillas;
            listadoNuevo[posBalloon].popBalloon();
            mainVM.casillas = listadoNuevo;*/
        }

        public async void addOnePoint()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                mainVM.puntuacionPersonal++;
            }
            );
        }

        public async void loadBalloons(Casilla[] casillas)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                List<CasillaVM> listado = new List<CasillaVM>();
                foreach (Casilla casilla in casillas)
                {
                    listado.Add(new CasillaVM(casilla.id, casilla.isBalloon, casilla.isPopped));
                }

                mainVM.casillas = listado;
            }
            );
        }

        public async void updateGlobalScore(int score)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                mainVM.puntuacionGlobal = score;
            }
            );
        }

        public async void updateNumberOfPlayers(int number)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
                {
                    mainVM.jugadoresEnLinea = number;
                }
            );
        }
        #endregion
    }
}
