using System;
using System.Collections.Generic;
using System.Text;

namespace AppUbicua.Models
{
    using Newtonsoft.Json;
    public class Cliente
    {
        [JsonProperty("id")]
        public string ClienteId { get; set; }
        [JsonProperty("nombre")]
        public string NombreCli { get; set; }
        [JsonProperty("nit")]
        public string NitCli { get; set; }
        [JsonProperty("correo")]
        public string CorreoCli { get; set; }
        [JsonProperty("celular")]
        public string CelularCli { get; set; }
        [JsonProperty("ubicacion")]
        public string UbicacionCli { get; set; }
        [JsonProperty("fecha")]
        public string FechaCli { get; set; }


    }
}
