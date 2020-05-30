using DomiciliosApp.Models;
using DomiciliosApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DomiciliosApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerTiendas : ContentPage
    {
        public ObservableCollection<Tienda> Tiendas { get; set; }
        private readonly TiendaService service;
        public VerTiendas()
        {
            InitializeComponent();
            service = new TiendaService();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Tiendas = await service.ObtenerTiendasApi();
            ListArtistas.ItemsSource = Tiendas;
        }

        private void ButtonProductos_Clicked(object sender, EventArgs e)
        {

        }

    }
}