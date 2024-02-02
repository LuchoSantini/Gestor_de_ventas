using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorVentasAPI.Data.Entities
{
    public class PagoProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdProveedor")]
        public Proveedor Proveedor { get; set; }
        public int IdProveedor { get; set; }
        public decimal Pagos { get; set; }
        public decimal MontoFinal { get; set; }
        // Agregar la prop fecha para que la tabla tenga sentido
    }
}
