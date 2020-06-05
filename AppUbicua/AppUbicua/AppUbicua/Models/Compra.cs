using System;
using System.Collections.Generic;
using System.Text;

namespace AppUbicua.Models
{
    using Newtonsoft.Json;
    public class Compra
    {
        [JsonProperty("id")]
        public string CompraId { get; set; }
        [JsonProperty("nombre")]
        public string NombreC { get; set; }
        [JsonProperty("nit")]
        public string NitC { get; set; }
        [JsonProperty("descripcion")]
        public string DescripcionC { get; set; }
        [JsonProperty("ubicacion")]
        public string UbicacionC { get; set; }
        [JsonProperty("fecha")]
        public string FechaC { get; set; }
        [JsonProperty("total")]
        public double TotalC { get; set; }

        public override string ToString()
        {
            return $"{this.NombreC}{this.NitC}";
        }

    }
}
