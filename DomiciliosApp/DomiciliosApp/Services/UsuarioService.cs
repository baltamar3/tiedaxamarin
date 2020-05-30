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
    public class UsuarioService
    {
        private readonly AppDbContext _context;
        private const string UsuariosAPI = "http://35.202.29.69:3000/sign_up";

        public UsuarioService()
        {
            _context = App.GetContext();
        }

        public void CrearUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CrearUsuarioApi(Usuario usuario)
        {
            try
            {
                var uri = "http://35.202.29.69:3000/sign_up";
                var cliente = new HttpClient();
                var json = JsonConvert.SerializeObject(usuario);
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

    }
}
