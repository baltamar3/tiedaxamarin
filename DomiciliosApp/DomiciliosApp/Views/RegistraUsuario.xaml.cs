using System;
using DomiciliosApp.Models;
using DomiciliosApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DomiciliosApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistraUsuario : ContentPage
    {
        public RegistraUsuario()
        {
            InitializeComponent();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e) {
            var current = Connectivity.NetworkAccess;

            if (EntryNombres.Text == null || EntryNombres.Text == "" ||
                EntryApellidos.Text == null || EntryApellidos.Text == "" ||
                EntryEmail.Text == null || EntryEmail.Text == "" ||
                EntryPassword.Text == null || EntryPassword.Text == "")
            {
                await DisplayAlert("Error", "Por favor Ingrese todos los Campos.", "Aceptar");
            }
            else if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin conexión", "Por favor asegúrese de tener conexión a Internet.", "Aceptar");
            }
            else 
            {
                try
                {
                    Usuario usuario = new Usuario
                    {
                        First_name = EntryNombres.Text,
                        Last_name = EntryApellidos.Text,
                        Email = EntryEmail.Text,
                        Password = EntryPassword.Text
                    };
                    UsuarioService service = new UsuarioService();
                    await service.CrearUsuarioApi(usuario);
                    await DisplayAlert("Exito", "Usted ha sido registrado exitosamente.", "Aceptar");
                    EntryNombres.Text = "";
                    EntryApellidos.Text = "";
                    EntryEmail.Text = "";
                    EntryPassword.Text = "";
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Ocurrio el siguiente error: " + ex.Message, "Aceptar");
                }
            }
        }

    }
}