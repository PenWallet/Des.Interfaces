using PennyDardos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PennyDardos.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace PennyDardos.ViewModels
{
    public class MainPageViewModel : clsVMBase
    {
        public MainPageViewModel(JugadorVM jugadorVM)
        {
            _casillas = new List<CasillaVM>();
            _puntuacionGlobal = 0;
            _casillaSeleccionada = 0;
            _jugador = jugadorVM;
            _isNotDoneLoading = true;

            #region SignalR
            conn = new HubConnection("https://pennydardos.azurewebsites.net/", $"username={jugador.nombre}&color={jugador.color}");
            proxy = conn.CreateHubProxy("DardosHub");
            conn.Start();

            proxy.On<int>("updateGlobalScore", updateGlobalScore);
            proxy.On<List<Jugador>>("updateRanking", updateRanking);
            proxy.On<List<Casilla>>("loadBalloons", loadBalloons);
            proxy.On<int>("updatePersonalScore", updatePersonalScore);
            proxy.On<int, string>("popBalloon", popBalloon);
            proxy.On("onConnectedIsDone", onConnectedIsDone);
            #endregion
        }

        #region Propiedades privadas
        private List<CasillaVM> _casillas;
        private int _puntuacionGlobal;
        private int _casillaSeleccionada;
        private List<Jugador> _ranking;
        private JugadorVM _jugador;
        private bool _isNotDoneLoading;
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

        public int casillaSeleccionada
        {
            get
            {
                return _casillaSeleccionada;
            }

            set
            {
                if (value != -1)
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

        public List<Jugador> ranking
        {
            get
            {
                return _ranking;
            }

            set
            {
                _ranking = value;
                NotifyPropertyChanged("ranking");
            }
        }

        public JugadorVM jugador
        {
            get
            {
                return _jugador;
            }

            set
            {
                _jugador = value;
                NotifyPropertyChanged("jugador");
            }
        }

        public bool isNotDoneLoading
        {
            get
            {
                return _isNotDoneLoading;
            }

            set
            {
                _isNotDoneLoading = value;
                NotifyPropertyChanged("isNotDoneLoading");
            }
        }
        #endregion

        #region Funciones Server
        public async void popBalloon(int posBalloon, string color)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                casillas[posBalloon].popBalloon(color);
                playPopSound();
            }
            );
        }

        private async void playPopSound()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("pop.wav");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
            mysong.Play();
        }

        public async void updatePersonalScore(int score)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                _jugador.puntuacion = score;
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
                    listado.Add(new CasillaVM(casilla.isBalloon, casilla.isPopped, casilla.background));
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

        public async void updateRanking(List<Jugador> ranking)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                this.ranking = ranking;
            }
            );
        }

        public async void onConnectedIsDone()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                this.isNotDoneLoading = false;
            }
            );
        }
        #endregion
    }
}
