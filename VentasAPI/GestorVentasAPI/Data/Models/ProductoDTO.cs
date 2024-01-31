using System.Text.Json.Serialization;

namespace GestorVentasAPI.Data.Models
{
    public class ProductoDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Calibre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
