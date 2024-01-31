using System.Text.Json.Serialization;

namespace GestorVentasAPI.Data.Models
{
    public class VentaDTO
    {
        public int IdCliente { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public int Id { get; set; }
    }
}
