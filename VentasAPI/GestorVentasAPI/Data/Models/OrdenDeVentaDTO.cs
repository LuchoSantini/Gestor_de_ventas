using Newtonsoft.Json;

namespace GestorVentasAPI.Data.Models
{
    public class OrdenDeVentaDTO
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        [JsonIgnore]
        public int IdCliente { get; set; }
    }
}
