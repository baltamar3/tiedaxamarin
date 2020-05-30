using System;
using DomiciliosApp.Models;
using DomiciliosApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DomiciliosApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearTienda : ContentPage
    {
        public CrearTienda()
        {
            InitializeComponent();
        }

        private async void ButtonCreateStore_Clicked(object sender, EventArgs e) {

            var current = Connectivity.NetworkAccess;

            if (EntryNombre.Text == null || EntryNombre.Text == "" ||
                EntryDescripcion.Text == null || EntryDescripcion.Text == "" ||
                EntryDireccion.Text == null || EntryDireccion.Text == "")
            {
                await DisplayAlert("Error", "Por favor Ingrese todos los Campos.", "Aceptar");
            }
            else if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin conexión", "Por favor asegúrese de tener conexión a Internet.", "Aceptar");
            }
            else 
            {
                try {
                    Tienda tienda = new Tienda
                    {
                        Nombre = EntryNombre.Text,
                        Descripcion = EntryDescripcion.Text,
                        Ubicacion = EntryDireccion.Text
                    };
                    TiendaService service = new TiendaService(); 
                    await service.CrearTiendaApi(tienda);
                    await DisplayAlert("Exito", "Tienda creada exitosamente.", "Aceptar");
                    EntryNombre.Text = "";
                    EntryDescripcion.Text = "";
                    EntryDireccion.Text = "";
                } 
                catch(Exception ex) 
                {
                    await DisplayAlert("Error", "Ocurrio el siguiente error: " + ex.Message, "Aceptar");
                }
            }

        }
    }
}