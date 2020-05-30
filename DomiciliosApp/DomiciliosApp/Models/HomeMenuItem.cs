using System;
using System.Collections.Generic;
using System.Text;

namespace DomiciliosApp.Models
{
    public enum MenuItemType
    {
        Registro,
        CrearTienda,
        VerTiendas
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
