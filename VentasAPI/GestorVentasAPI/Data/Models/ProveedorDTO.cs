using GestorVentasAPI.Enums;
using System.Text.Json.Serialization;

namespace GestorVentasAPI.Data.Models
{
    public class ProveedorDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [JsonIgnore]
        public EstadoUsuario Estado { get; set; }
    }
}
