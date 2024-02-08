using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentasAPI.Data.Entities
{
    public class OrdenDeVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public string FechaCreacion { get; set; }
    }
}
