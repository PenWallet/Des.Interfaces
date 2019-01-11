using PennyDardos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PennyDardos.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using Windows.UI.Core;

namespace PennyDardos.ViewModels
{
    public class MainPageViewModel : clsVMBase
    {
        public MainPageViewModel()
        {
            _casillas = new List<CasillaVM>();
            _puntuacionGlobal = 0;
            _puntuacionPersonal = 0;
            _jugadoresEnLinea = 0;
            _casillaSeleccionada = 0;

            #region SignalR
            conn = new HubConnection("https://pennydardos.azurewebsites.net/");
            proxy = conn.CreateHubProxy("DardosHub");
            conn.Start();

            proxy.On<int>("updateGlobalScore", updateGlobalScore);
            proxy.On<int>("updateNumberOfPlayers", updateNumberOfPlayers);
            proxy.On<List<Casilla>>("loadBalloons", loadBalloons);
            proxy.On("addOnePoint", addOnePoint);
            proxy.On<int>("popBalloon", popBalloon);
            #endregion
        }

        #region Propiedades privadas
        private List<CasillaVM> _casillas;
        private int _puntuacionGlobal;
        private int _puntuacionPersonal;
        private int _jugadoresEnLinea;
        private int _casillaSeleccionada;
        #endregion

        #region Propiedades públicas
        public HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        public List<CasillaVM> casillas
        {
            get
            {
                return _casillas;
            }

            set
            {
                _casillas = value;
                NotifyPropertyChanged("casillas");
            }
        }

        public int puntuacionGlobal
        {
            get
            {
                return _puntuacionGlobal;
            }

            set
            {
                _puntuacionGlobal = value;
                NotifyPropertyChanged("puntuacionGlobal");
            }
        }

        public int puntuacionPersonal
        {
            get
            {
                return _puntuacionPersonal;
            }

            set
            {
                _puntuacionPersonal = value;
                NotifyPropertyChanged("puntuacionPersonal");
            }
        }

        public int jugadoresEnLinea
        {
            get
            {
                return _jugadoresEnLinea;
            }

            set
            {
                _jugadoresEnLinea = value;
                NotifyPropertyChanged("jugadoresEnLinea");
            }
        }

        public int casillaSeleccionada
        {
            get
            {
                return _casillaSeleccionada;
            }

            set
            {
                if(value != -1)
                {
                    _casillaSeleccionada = value;
                    CasillaVM casilla = _casillas[_casillaSeleccionada];
                    if (casilla.isBalloon && !casilla.isPopped)
                    {
                        proxy.Invoke("press", _casillaSeleccionada);
                    }
                }
                
            }
        }
        #endregion

        #region Funciones Server
        public async void popBalloon(int posBalloon)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                casillas[posBalloon].popBalloon();
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
                puntuacionPersonal++;
            }
            );
        }

        public async void loadBalloons(List<Casilla> casillas)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                List<CasillaVM> listado = new List<CasillaVM>();
                foreach (Casilla casilla in casillas)
                {
                    listado.Add(new CasillaVM(casilla.isBalloon, casilla.isPopped));
                }

                this.casillas = listado;
            }
            );
        }

        public async void updateGlobalScore(int score)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                puntuacionGlobal = score;
            }
            );
        }

        public async void updateNumberOfPlayers(int number)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                jugadoresEnLinea = number;
            }
            );
        }
        #endregion
    }
}
