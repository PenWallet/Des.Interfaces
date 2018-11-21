using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ViewModels;
using Windows.UI.Popups;

namespace ViewModels
{
    /// <summary>
    /// ViewModel que le proporcionará lo necesario a MainPage para funcionar correctamente
    ///     - Lista de casillas
    ///     - Casilla seleccionada
    ///     - Comando cuando se pulse el botón de nueva partida
    ///     - Contador de salvadas
    ///     - Boolean indicando si la partida ha acabado o no
    /// </summary>
    public class MainPageViewModel : clsVMBase
    {
        #region Propiedades privadas
        private List<ClsCasilla> _listadoCasillas;
        private ClsCasilla _casillaSeleccionada;
        private DelegateCommand _nuevaPartidaCommand;
        private int _contadorSalvados;
        private bool _partidaEstaAcabada;
        #endregion

        #region Propiedades públicas
        public List<ClsCasilla> listadoCasillas
        {
            get
            {
                return _listadoCasillas;
            }

            set
            {
                _listadoCasillas = value;
                NotifyPropertyChanged("listadoCasillas");
            }
        }

        public ClsCasilla casillaSeleccionada
        {
            get
            {
                return _casillaSeleccionada;
            }

            set
            {
                _casillaSeleccionada = value;
                if(_casillaSeleccionada != null && !_partidaEstaAcabada && !_casillaSeleccionada.estaPresionada)
                {
                    _casillaSeleccionada.rutaImagen = _casillaSeleccionada.esBomba ? "../Assets/Imagenes/bomba.png" : "../Assets/Imagenes/salvado.png";
                    _casillaSeleccionada.estaPresionada = true;

                    NotifyPropertyChanged("casillaSeleccionada");

                    if (_casillaSeleccionada.esBomba)
                    {
                        mostrarGameOver();
                        _casillaSeleccionada.borderColor = "Red";
                        _partidaEstaAcabada = true;
                    }
                    else
                    {
                        _contadorSalvados++;
                        _casillaSeleccionada.borderColor = "LightGreen";
                        NotifyPropertyChanged("contadorSalvados");

                        if (_contadorSalvados == 5)
                        {
                            mostrarGanador();
                            _partidaEstaAcabada = true;
                        }
                    }
                }
            }
        }

        public int contadorSalvados
        {
            get
            {
                return _contadorSalvados;
            }
        }

        public DelegateCommand nuevaPartidaCommand
        {
            get
            {
                _nuevaPartidaCommand = new DelegateCommand(nuevaPartidaCommand_Executed);
                return _nuevaPartidaCommand;
            }
        }
        #endregion

        #region Constructores
        public MainPageViewModel()
        {
            //Primero rellenamos el listado de casillas
            listadoCasillas = rellenarListaCasillas();

            //No hay ninguna casilla seleccionada, así que está a null
            _casillaSeleccionada = null;

            //El contador está a 0 al principio de la partida
            _contadorSalvados = 0;

            //La partida no está acabada
            _partidaEstaAcabada = false;
        }
        #endregion

        #region Commands
        /// <summary>
        /// Comando que ejecuta empezarNuevaPartida para... exactamente eso, empezar una nueva partida
        /// </summary>
        private void nuevaPartidaCommand_Executed()
        {
            empezarNuevaPartida();
        }
        #endregion
        

        #region Funciones
        /// <summary>
        /// Función que devuelve una lista con 16 bombas, de las cuales 5 son bombas, elegidas al azar
        /// </summary>
        /// <returns>List<ClsCasilla></returns>
        private List<ClsCasilla> rellenarListaCasillas()
        {
            Random random = new Random();
            List<ClsCasilla> lista = new List<ClsCasilla>();
            ClsCasilla casilla;
            int casBomb1, casBomb2, casBomb3, casBomb4, casBomb5;
            casBomb1 = random.Next(0, 15);
            do
            {
                casBomb2 = random.Next(0, 15);
            } while (casBomb2 == casBomb1);
            do
            {
                casBomb3 = random.Next(0, 15);
            } while (casBomb3 == casBomb1 || casBomb3 == casBomb2);
            do
            {
                casBomb4 = random.Next(0, 15);
            } while (casBomb4 == casBomb1 || casBomb4 == casBomb2 || casBomb4 == casBomb3);
            do
            {
                casBomb5 = random.Next(0, 15);
            } while (casBomb5 == casBomb1 || casBomb5 == casBomb2 || casBomb5 == casBomb3 || casBomb5 == casBomb4);

            for(int i = 0; i < 16; i++)
            {
                if (i == casBomb1 || i == casBomb2 || i == casBomb3 || i == casBomb4 || i == casBomb5)
                    casilla = new ClsCasilla(true);
                else
                    casilla = new ClsCasilla(false);

                lista.Add(casilla);
            }

            return lista;
        }

        private async void mostrarGameOver()
        {
            var dialog = new MessageDialog("¡Pulsaste una bomba! Taluego loco");
            await dialog.ShowAsync();
        }

        private async void mostrarGanador()
        {
            var dialog = new MessageDialog("¡Ganaste! HUEEE");
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Esta función hace que empiece una partida de nuevo:
        ///     Resetea la casilla seleccionada null
        ///     Resetea el contador de salvados a 0
        ///     Resetea la imagen a presionar
        ///     Rellena el listado de casillas con casillas nuevas
        ///     Resetea el boolean que indica si la partida está acabada
        /// </summary>
        private void empezarNuevaPartida()
        {
            _casillaSeleccionada = null;
            _contadorSalvados = 0; NotifyPropertyChanged("contadorSalvados");
            _listadoCasillas = rellenarListaCasillas();
            NotifyPropertyChanged("listadoCasillas");
            _partidaEstaAcabada = false;
        }
        #endregion
    }
}
