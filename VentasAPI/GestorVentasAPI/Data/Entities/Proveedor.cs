using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestorVentasAPI.Enums;

namespace GestorVentasAPI.Data.Entities
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public EstadoUsuario Estado { get; set; }
    }
}
