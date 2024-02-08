using System.Text.Json.Serialization;

namespace GestorVentasAPI.Data.Models
{
    public class ClienteDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [JsonIgnore]
        public string FechaCreacion { get; set; }
    }
}
