using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DomiciliosApp.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Tienda
    {
        [JsonProperty("id")]
        public int TiendaID { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("description")]
        public string Descripcion { get; set; }
        
        [JsonProperty("address")]
        public string Ubicacion { get; set; }

        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

    }
}
