using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorVentasAPI.Data.Entities
{
    public class IngresoCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Ingresos { get; set; }
        //public decimal PagoProveedores { get; set; }
        public decimal MontoFinal { get; set; }
        // Agregar la prop fecha para que la tabla tenga sentido

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } // Necesito el monto de su venta cobrada
        public int IdCliente { get; set; }
        //[ForeignKey("IdProveedor")]
        //public Proveedor Proveedor { get; set; }
        //public int IdProveedor { get; set; }
        //[ForeignKey("IdDeudaCliente")]
        //public DeudaCliente DeudaCliente { get; set; }
        //public int IdDeudaCliente { get; set; }
    }
}
