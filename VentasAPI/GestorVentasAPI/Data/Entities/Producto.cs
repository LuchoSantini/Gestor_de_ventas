using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorVentasAPI.Data.Entities
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Calibre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Precio { get; set;}
    }
}
