using System.Text.Json.Serialization;

namespace GestorVentasAPI.Data.Models
{
    public class PagoProveedorDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public decimal MontoAPagar { get; set; }
    }
}
