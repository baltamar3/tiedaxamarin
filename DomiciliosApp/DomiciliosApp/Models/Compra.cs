using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomiciliosApp.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Compra
    {
        [JsonProperty("id")]
        public int CompraID { get; set; }

        [JsonProperty("product_id")]
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }

        [JsonProperty("group")]
        public int Grupo { get; set; }

        [JsonProperty("quantity")]
        public int Cantidad { get; set; }

        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}
