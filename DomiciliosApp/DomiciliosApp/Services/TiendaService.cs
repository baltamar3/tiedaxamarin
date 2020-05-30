using DomiciliosApp.Contexts;
using DomiciliosApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DomiciliosApp.Services
{
    public class TiendaService
    {
        private readonly AppDbContext _context;
        private const string TiendasAPI = "http://35.202.29.69:3000/stores";

        public TiendaService()
        {
            _context = App.GetContext();
        }

        public ObservableCollection<Tienda> ObtenerTiendas()
        {
            return _context.Tiendas.ToObservableCollection();
        }

        public List<Tienda> ObtenerListArtistas()
        {
            return _context.Tiendas.ToList();
        }

        public void CrearTienda(Tienda tienda)
        {
            try
            {
                _context.Tiendas.Add(tienda);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CrearTiendaApi(Tienda tienda)
        {
            try
            {
                var uri = TiendasAPI;
                var cliente = new HttpClient();
                var json = JsonConvert.SerializeObject(tienda);
                HttpResponseMessage response;
                byte[] byteData = Encoding.UTF8.GetBytes(json);
                using var content = new ByteArrayContent(byteData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await cliente.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }


        }

        public async Task<ObservableCollection<Tienda>> ObtenerTiendasApi()
        {
            List<Tienda> objetos = new List<Tienda>();
            try
            {
                Uri uri = new Uri(string.Format(TiendasAPI, string.Empty));
                HttpClient cliente = new HttpClient();
                var response = await cliente.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    objetos = JsonConvert.DeserializeObject<List<Tienda>>(contenido);
                }
            }
            catch (Exception)
            {
            }
            return objetos.ToObservableCollection();
        }

    }
}
