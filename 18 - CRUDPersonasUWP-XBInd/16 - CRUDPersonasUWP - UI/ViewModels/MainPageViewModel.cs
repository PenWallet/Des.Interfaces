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
        private ObservableCollection<ClsPersona> _listadoPersonasCompleto;
        private ObservableCollection<ClsPersona> _listadoPersonasBusqueda;
        private ClsPersona _personaSeleccionada;
        private List<ClsDepartamento> _listadoDepartamentos;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _crearCommand;
        private DelegateCommand _actualizarPersonaCommand;
        private DelegateCommand _actualizarListadoCommand;
        private string _mensajeErrorNombre;
        private string _mensajeErrorApellidos;
        private string _mensajeErrorFechaNac;
        private string _mensajeErrorDireccion;
        private string _mensajeErrorTelefono;
        private string _mensajeErrorDepartamento;
        private string _textoBusqueda;
        #endregion

        #region Propiedades públicas
        //public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ClsPersona> listadoPersonasBusqueda
        {
            get
            {
                return _listadoPersonasBusqueda;
            }

            set
            {
                _listadoPersonasBusqueda = value;
                NotifyPropertyChanged("listadoPersonasBusqueda");
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
                if(_personaSeleccionada != value)
                {
                    _personaSeleccionada = value;

                    //Cambiar los mensajes de error en caso de que estén aún en pantalla
                    mensajeErrorApellidos = "";
                    mensajeErrorDepartamento = "";
                    mensajeErrorDireccion = "";
                    mensajeErrorFechaNac = "";
                    mensajeErrorNombre = "";
                    mensajeErrorTelefono = "";

                    //Llamamos a CanExecute de eliminar, actualizar y crear para que compruebe si debe habilitar el comando
                    _eliminarCommand.RaiseCanExecuteChanged();
                    _crearCommand.RaiseCanExecuteChanged();
                    _actualizarPersonaCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("personaSeleccionada");
                } 
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
                _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarOActualizarCommand_CanExecute);
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

        public DelegateCommand crearCommand
        {
            get
            {
                _crearCommand = new DelegateCommand(CrearPersonaCommand_Executed, CrearCommand_CanExecute);
                return _crearCommand;
            }
        }

        public DelegateCommand actualizarPersonaCommand
        {
            get
            {
                _actualizarPersonaCommand = new DelegateCommand(ActualizarPersonaCommand_Executed, EliminarOActualizarCommand_CanExecute);
                return _actualizarPersonaCommand;
            }
        }

        public string mensajeErrorNombre
        {
            set
            {
                _mensajeErrorNombre = value;
                NotifyPropertyChanged("mensajeErrorNombre");
            }

            get
            {
                return _mensajeErrorNombre;
            }
        }

        public string mensajeErrorApellidos
        {
            set
            {
                _mensajeErrorApellidos = value;
                NotifyPropertyChanged("mensajeErrorApellidos");
            }

            get
            {
                return _mensajeErrorApellidos;
            }
        }

        public string mensajeErrorFechaNac
        {
            set
            {
                _mensajeErrorFechaNac = value;
                NotifyPropertyChanged("mensajeErrorFechaNac");
            }

            get
            {
                return _mensajeErrorFechaNac;
            }
        }

        public string mensajeErrorDireccion
        {
            set
            {
                _mensajeErrorDireccion = value;
                NotifyPropertyChanged("mensajeErrorDireccion");
            }

            get
            {
                return _mensajeErrorDireccion;
            }
        }

        public string mensajeErrorTelefono
        {
            set
            {
                _mensajeErrorTelefono = value;
                NotifyPropertyChanged("mensajeErrorTelefono");
            }

            get
            {
                return _mensajeErrorTelefono;
            }
        }

        public string mensajeErrorDepartamento
        {
            set
            {
                _mensajeErrorDepartamento = value;
                NotifyPropertyChanged("mensajeErrorDepartamento");
            }

            get
            {
                return _mensajeErrorDepartamento;
            }
        }

        public string textoBusqueda
        {
            set
            {
                _textoBusqueda = value;
                listadoPersonasBusqueda = new ObservableCollection<ClsPersona>(_listadoPersonasCompleto.Where(x => x.Contains(_textoBusqueda)).ToList());
                NotifyPropertyChanged("listadoPersonasBusqueda");
                NotifyPropertyChanged("textoBusqueda");
            }

            get
            {
                return _textoBusqueda;
            }
        }
        #endregion


        #region Constructor por defecto
        public MainPageViewModel()
        {
            //Cargar listado de personas
            _listadoPersonasCompleto = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());
            listadoPersonasBusqueda = _listadoPersonasCompleto;

            //Cargar listado de departamentos
            listadoDepartamentos = clsListadoDepartamentos_BL.listadoCompletoDepartamentos_BL();

            //Ponemos una persona por defecto
            _personaSeleccionada = new ClsPersona();

            //Poner el texto de búsqueda como "" por defecto
            _textoBusqueda = "";
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

        private async void CrearPersonaCommand_Executed()
        {
            bool sePuedeCrear = comprobarDatos();

            if (sePuedeCrear)
            {
                try
                {
                    var dialog = new MessageDialog("¿Deseas crear a la persona?");

                    dialog.Commands.Add(new UICommand("Sí") { Id = 0 });
                    dialog.Commands.Add(new UICommand("No") { Id = 1 });

                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;

                    var result = await dialog.ShowAsync();

                    if ((int)result.Id == 0)
                    {
                        int filas = ClsManejadoraPersona_BL.CrearPersona_BL(_personaSeleccionada);

                        if (filas == 0)
                            mostrarErrorCrear();
                        else if (filas == 1)
                        {
                            mostrarExitoCrear();
                            _listadoPersonasCompleto = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());
                            personaSeleccionada = new ClsPersona();
                            textoBusqueda = "";
                        }
                        else
                            mostrarWTF();
                    }
                }
                catch (SqlException) { mostrarErrorBorrar(); }
            }
        }

        /// <summary>
        /// Comando que borra de la base de datos a la persona seleccionada
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            try
            {
                var dialog = new MessageDialog("¿Deseas borrar a la persona?");

                dialog.Commands.Add(new UICommand("Sí") { Id = 0 });
                dialog.Commands.Add(new UICommand("No") { Id = 1 });

                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;

                var result = await dialog.ShowAsync();

                if ((int)result.Id == 0)
                {
                    int filas = ClsManejadoraPersona_BL.BorrarPorID_BL(_personaSeleccionada.idPersona);

                    if (filas == 0)
                        mostrarErrorBorrar();
                    else if (filas == 1)
                    {
                        mostrarExitoBorrar();
                        _listadoPersonasCompleto.Remove(_personaSeleccionada);
                        personaSeleccionada = new ClsPersona();
                        textoBusqueda = _textoBusqueda;
                    }
                    else
                        mostrarWTF();
                }
            }
            catch (SqlException) { mostrarErrorBorrar(); }
        }

        /// <summary>
        /// Función que actualiza el listado de personas
        /// </summary>
        private void ActualizarListadoCommand_Executed()
        {
            _listadoPersonasCompleto = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());
            personaSeleccionada = new ClsPersona();
            textoBusqueda = "";
        }

        /// <summary>
        /// Comando que actualiza los datos de la persona que se haya seleccionado a los datos que haya escrito en los campos del
        /// formulario
        /// </summary>
        private async void ActualizarPersonaCommand_Executed()
        {
            bool sePuedeActualizar = comprobarDatos();

            if(sePuedeActualizar)
            {
                try
                {
                    var dialog = new MessageDialog("¿Deseas actualizar a la persona?");

                    dialog.Commands.Add(new UICommand("Sí") { Id = 0 });
                    dialog.Commands.Add(new UICommand("No") { Id = 1 });

                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;

                    var result = await dialog.ShowAsync();

                    if ((int)result.Id == 0)
                    {
                        int filas = ClsManejadoraPersona_BL.ActualizarPersona_BL(_personaSeleccionada);

                        if (filas == 0)
                            mostrarErrorActualizar();
                        else if (filas == 1)
                        {
                            mostrarExitoActualizar();
                            _listadoPersonasCompleto = new ObservableCollection<ClsPersona>(ClsListadoPersonas_BL.listadoCompletoPersonas_BL());
                            personaSeleccionada = new ClsPersona();
                            textoBusqueda = "";
                        }
                        else
                            mostrarWTF();
                    }
                }
                catch (SqlException) { mostrarErrorBorrar(); }
            }
            
        }

        /// <summary>
        /// Función que devuelve un booleano para habilitar o deshabilitar los controles bindeados o enlazados al comando eliminar y al de actualizar
        /// 
        /// Devuelve true cuando la ID de la persona seleccionada no sea 0, false en caso contrario
        /// </summary>
        /// <returns>bool</returns>
        private bool EliminarOActualizarCommand_CanExecute()
        {
            bool habilitado = false;

            if (_personaSeleccionada != null && _personaSeleccionada.idPersona != 0)
                habilitado = true;

            return habilitado;
        }

        /// <summary>
        /// Función que devuelve un booleano para habilitar o deshabilitar los controles bindeados o enlazados al comando crear
        /// 
        /// Devuelve true cuando la ID de la persona seleccionada sea 0, false en caso contrario
        /// </summary>
        /// <returns>bool</returns>
        private bool CrearCommand_CanExecute()
        {
            bool habilitado = false;

            if (_personaSeleccionada == null || _personaSeleccionada.idPersona == 0)
                habilitado = true;

            return habilitado;
        }
        #endregion


        #region "Funciones"
        private async void mostrarErrorBorrar()
        {
            var dialog = new MessageDialog("No se pudo borrar la persona");
            await dialog.ShowAsync();
        }

        private async void mostrarExitoBorrar()
        {
            var dialog = new MessageDialog("La persona se ha borrado correctamente");
            await dialog.ShowAsync();
        }

        private async void mostrarErrorActualizar()
        {
            var dialog = new MessageDialog("No se pudo actualizar la persona");
            await dialog.ShowAsync();
        }

        private async void mostrarExitoActualizar()
        {
            var dialog = new MessageDialog("La persona se ha actualizado correctamente");
            await dialog.ShowAsync();
        }

        private async void mostrarErrorCrear()
        {
            var dialog = new MessageDialog("No se pudo crear la persona");
            await dialog.ShowAsync();
        }

        private async void mostrarExitoCrear()
        {
            var dialog = new MessageDialog("La persona se ha creado correctamente");
            await dialog.ShowAsync();
        }

        private async void mostrarWTF()
        {
            var dialog = new MessageDialog("Algo ha ido horriblemente mal wtf");
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Función que se encarga de comprobar si los datos que hay escritos en los textboxes, datepickers y comboboxes son correctos
        /// 
        /// En caso de estar todo correcto devuelve true, y si algo falla, false
        /// </summary>
        /// <returns>bool</returns>
        private bool comprobarDatos()
        {
            //Cada boolean indica si hay un error en cada apartado o no
            bool eNombre, eApellidos, eFecha, eDireccion, eTelefono, eDepartamento, total;

            //Validar nombre
            if (_personaSeleccionada.nombre == "")
            {
                eNombre = true;
                mensajeErrorNombre = "¡El nombre no puede estar vacío!";
            }
            else
            {
                eNombre = false;
                mensajeErrorNombre = "";
            }

            //Validar apellidos
            if (_personaSeleccionada.apellidos == "")
            {
                eApellidos = true;
                mensajeErrorApellidos = "¡Los apellidos no pueden estar vacíos!";
            }
            else
            {
                eApellidos = false;
                mensajeErrorApellidos = "";
            }

            //Validar fecha de nacimiento
            if (_personaSeleccionada.fechaNac.Date == new DateTime(1918, 1, 1).Date)
            {
                eFecha = true;
                mensajeErrorFechaNac = "Enga abuelete, no mientas anda";
            }
            else
            {
                eFecha = false;
                mensajeErrorFechaNac = "";
            }

            //Validar dirección
            if (_personaSeleccionada.direccion == "")
            {
                eDireccion = true;
                mensajeErrorDireccion = "¡La dirección no puede estar vacía!";
            }
            else
            {
                eDireccion = false;
                mensajeErrorDireccion = "";
            }

            //Validar teléfono
            if (_personaSeleccionada.telefono == "")
            {
                eTelefono = true;
                mensajeErrorTelefono = "¡El teléfono no puede estar vacío!";
            }
            else
            {
                eTelefono = false;
                mensajeErrorTelefono = "";
            }

            //Validar departamento
            if (_personaSeleccionada.idDepartamento == 0)
            {
                eDepartamento = true;
                mensajeErrorDepartamento = "¡El departamento no puede estar vacío!";
            }
            else
            {
                eDepartamento = false;
                mensajeErrorDepartamento = "";
            }

            if (!eNombre && !eApellidos && !eFecha && !eDireccion && !eTelefono && !eDepartamento)
                total = true;
            else
                total = false;

            return total;
        }
        #endregion

    }
}