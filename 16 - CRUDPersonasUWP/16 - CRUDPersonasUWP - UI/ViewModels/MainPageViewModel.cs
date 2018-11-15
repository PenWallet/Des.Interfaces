using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using BL.Listados;
using System.Data.SqlClient;
using Windows.UI.Popups;
using BL.Manejadoras;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class MainPageViewModel : clsVMBase
    {
        #region Propiedades privadas
        private ObservableCollection<ClsPersona> _listadoPersonas;
        private ClsPersona _personaSeleccionada;
        private List<ClsDepartamento> _listadoDepartamentos;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _actualizarListadoCommand;
        #endregion

        #region Propiedades públicas
        //public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ClsPersona> listadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }

            set
            {
                _listadoPersonas = value;
                NotifyPropertyChanged("listadoPersonas");
            }
        }

        public ClsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }

            set
            {
                _personaSeleccionada = value;
                //Llamamos a CanExecute de eliminar para que compruebe si debe habilitar el comando
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }

        public List<ClsDepartamento> listadoDepartamentos
        {
            get
            {
                return _listadoDepartamentos;
            }

            set
            {
                _listadoDepartamentos = value;
            }
        }

        public DelegateCommand eliminarCommand
        {
            get
            {
                _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
                return _eliminarCommand;
            }
        }

        public DelegateCommand actualizarListadoCommand
        {
            get
            {
                _actualizarListadoCommand = new DelegateCommand(ActualizarListadoCommand_Executed);
                return _actualizarListadoCommand;
            }
        }
        #endregion


        #region Constructor por defecto
        public MainPageViewModel()
        {
            //Cargar listado de personas
            listadoPersonas = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());

            //Cargar listado de departamentos
            listadoDepartamentos = clsListadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
        }
        #endregion


        #region "Comandos"
        /*
         * Al utilizar la clase clsVMbase, no hace falta esta función
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        */

        private async void EliminarCommand_Executed()
        {
            try
            {
                var dialog = new Windows.UI.Popups.MessageDialog("¿Deseas borrar a la persona?");

                dialog.Commands.Add(new UICommand("Sí") { Id = 0 });
                dialog.Commands.Add(new UICommand("No") { Id = 1 });

                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;

                var result = await dialog.ShowAsync();

                if ((int)result.Id == 0)
                {
                    int filas = ClsManejadoraPersona_BL.BorrarPorID_BL(personaSeleccionada.idPersona);

                    if (filas == 0)
                        mostrarError();
                    else if (filas == 1)
                    {
                        mostrarExito();
                        listadoPersonas = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());
                    }
                    else
                        mostrarWTF();
                }
            }
            catch (SqlException) { mostrarError(); }
        }

        /// <summary>
        /// Función que actualiza el listado de personas
        /// </summary>
        private void ActualizarListadoCommand_Executed()
        {
            personaSeleccionada = null;
            listadoPersonas = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());

        }

        private void ActualizarPersonaCommand_Executed()
        {

        }

        /// <summary>
        /// Función que devuelve un booleano para habilitar o deshabilitar los controles bindeados o enlazados al comando eliminar
        /// </summary>
        /// <returns>bool</returns>
        private bool EliminarCommand_CanExecute()
        {
            bool habilitado = false;

            if(personaSeleccionada != null)
                habilitado = true;

            return habilitado;
        }
        #endregion


        #region "Funciones"
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
        #endregion

    }
}