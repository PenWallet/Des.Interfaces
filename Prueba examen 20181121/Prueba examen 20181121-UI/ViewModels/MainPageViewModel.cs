using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using BL.Listados;

namespace ViewModels
{
    /// <summary>
    /// Este es el ViewModel que el MainPage necesitará, que es lo siguiente:
    /// 
    ///     - ListadoCategorías: Consultable
    ///     - ListadoPersonajes: Consultable
    ///     - ListadoPersonajesPorCategoria: Consultable, modificable
    ///     - CampeónSeleccionado: Consultable, modificable
    ///     - IDCategoriaSeleccionada: Consultable, modificable
    /// </summary>
    public class MainPageViewModel : clsVMBase
    {
        #region Propiedades privadas
        private List<ClsCategoria> _listadoCategorias;
        private List<ClsCampeon> _listadoCampeones;
        private List<ClsCampeon> _listadoCampeonesPorCategoria;
        private ClsCampeon _campeonSeleccionado;
        private int _idCategoriaSeleccionada;
        private string _infoVisibility;
        #endregion

        #region Propiedades públicas
        public List<ClsCategoria> listadoCategorias
        {
            get
            {
                return _listadoCategorias;
            }
        }

        public List<ClsCampeon> listadoCampeones
        {
            get
            {
                return _listadoCampeones;
            }
        }

        public List<ClsCampeon> listadoCampeonesPorCategoria
        {
            get
            {
                return _listadoCampeonesPorCategoria;
            }

            set
            {
                _listadoCampeonesPorCategoria = value;
                NotifyPropertyChanged("listadoCampeonesPorCategoria");
            }
        }

        public ClsCampeon campeonSeleccionado
        {
            get
            {
                return _campeonSeleccionado;
            }

            set
            {
                _campeonSeleccionado = value == null ? new ClsCampeon() : value;
                infoVisibility = _campeonSeleccionado.ID == 0 ? "Collapsed" : "Visible";
                NotifyPropertyChanged("campeonSeleccionado");
            }
        }

        public int idCategoriaSeleccionada
        {
            get
            {
                return _idCategoriaSeleccionada;
            }

            set
            {
                _idCategoriaSeleccionada = value;
                campeonSeleccionado = new ClsCampeon();
                listadoCampeonesPorCategoria = _listadoCampeones.Where(x => x.IDCategoria == _idCategoriaSeleccionada).ToList();
            }
        }

        public string infoVisibility
        {
            get
            {
                return _infoVisibility;
            }

            set
            {
                _infoVisibility = value;
                NotifyPropertyChanged("infoVisibility");
            }
        }
        #endregion

        #region Constructores
        public MainPageViewModel()
        {
            //Rellenamos el listado de las categorías
            _listadoCategorias = ClsListadoCategorias_BL.listadoCompletoCategorias_BL();

            //Rellenamos el listado de todos los personajes
            _listadoCampeones = ClsListadoPersonajes_BL.listadoCompletoPersonajes_DAL();

            //Cremos una lista vacía del listado de campeones por categoría
            _listadoCampeonesPorCategoria = new List<ClsCampeon>();

            //Iniciamos el campeón a uno vacío
            _campeonSeleccionado = new ClsCampeon();

            //Iniciamos la categoría elegida a 0
            _idCategoriaSeleccionada = 0;

            //La información estará colapsada
            infoVisibility = "Collapsed";
        }
        #endregion
    }
}
