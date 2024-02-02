using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorVentasAPI.Data.Entities
{
    public class FlujoFondo
    {
        // En esta entidad se maneja el flujo de dinero
        // Agregar fechas para IngresosClientes y PagoProveedores
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdIngresoCliente")]
        public IngresoCliente IngresoCliente { get; set; }
        public int IdIngresoCliente { get; set; }
        [ForeignKey("IdPagoProveedor")]
        public PagoProveedor PagoProveedor { get; set; }
        public int IdPagoProveedor { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        [ForeignKey("IdProveedor")]
        public Proveedor Proveedor { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Pagos { get; set; }
        // SaldoFinal = Ingresos - PagoProveedor
        public decimal SaldoFinal { get; set; }
    }
}
