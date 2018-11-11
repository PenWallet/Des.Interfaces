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
using BL.Manejadoras;
using Entidades;
using System.Data.SqlClient;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _16___CRUDPersonasUWP___UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPerson : Page
    {
        public AddPerson()
        {
            this.InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool eNombre = false, eApellidos = false, eFecha = false, eDireccion = false, eTelefono = false, eDepartamento = false;

            if (txtNombre.Text == "")
            {
                txtErrorNombre.Text = "¡No puede estar vacío!";
                eNombre = true;
            }
            else
                txtErrorNombre.Text = "";

            if (txtApellidos.Text == "")
            {
                txtErrorApellidos.Text = "¡No puede estar vacío!";
                eApellidos = true;
            }
            else
                txtErrorApellidos.Text = "";

            if (txtFecha.Text == "")
            {
                txtErrorFecha.Text = "¡No puede estar vacío!";
                eFecha = true;
            }
            else
                txtErrorFecha.Text = "";

            if (txtDireccion.Text == "")
            {
                txtErrorDireccion.Text = "¡No puede estar vacío!";
                eDireccion = true;
            }
            else
                txtErrorDireccion.Text = "";

            if (txtTelefono.Text == "")
            {
                txtErrorTelefono.Text = "¡No puede estar vacío!";
                eTelefono = true;
            }
            else
                txtErrorTelefono.Text = "";

            if(cbDepartamento.SelectedItem == null)
            {
                txtErrorDepartamento.Text = "¡Debes elegir un departamento!";
                eDepartamento = true;
            }
            else
                txtErrorDepartamento.Text = "";

            if (!eNombre && !eApellidos && !eFecha && !eDireccion && !eTelefono && !eDepartamento)
            {
                DateTime fecha;
                int filas = 0;
                

                DateTime.TryParse(txtFecha.Text, out fecha);
                ClsPersona p1 = new ClsPersona(0, txtNombre.Text, txtApellidos.Text, fecha, txtDireccion.Text, txtTelefono.Text, (int)cbDepartamento.SelectedValue);

                try
                {
                    filas = ClsManejadoraPersona_BL.CrearPersona_BL(p1);
                }
                catch (SqlException) { mostrarError(); }

                if (filas == 0)
                    mostrarError();
                else
                    mostrarExito();

            }
        }

        private async void mostrarError()
        {
            var dialog = new MessageDialog("No se pudo crear la persona");
            await dialog.ShowAsync();
        }

        private async void mostrarExito()
        {
            var dialog = new MessageDialog("La persona se ha creado");
            await dialog.ShowAsync();
        }
    }
}
