using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomiciliosApp.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Producto
    {
        [JsonProperty("id")]
        public int ProductoID { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("description")]
        public string Descripcion { get; set; }

        [JsonProperty("price")]
        public double Precio { get; set; }

        [JsonProperty("store_id")]
        public int TiendaID { get; set; }
        public Tienda Tienda { get; set; }
    }
}
