namespace AppUbicua.Models
{
    using Newtonsoft.Json;
    public class ConsultaCompra
    {
        [JsonProperty("id")]
        public string ConsultaCompraId { get; set; }
        [JsonProperty("producto")]
        public string CProducto { get; set; }
        [JsonProperty("cantidad")]
        public string CCantidad { get; set; }
        [JsonProperty("total")]
        public string CTotal { get; set; }

       public override string ToString()
        {
           return $"{this.CProducto} {this.CTotal}";
        }
    }
}
