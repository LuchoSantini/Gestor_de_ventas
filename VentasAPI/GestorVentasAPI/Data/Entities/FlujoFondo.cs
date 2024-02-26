using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace GestorVentasAPI.Data.Entities
{
    public class FlujoFondo
    {
        // En esta entidad se maneja el flujo de dinero
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoFinal { get; set; }
        //[ForeignKey("IdIngresoCliente")]
        //public IngresoCliente IngresoCliente { get; set; }
        //public int IdIngresoCliente { get; set; }
        //[ForeignKey("IdPagoProveedor")]
        //public PagoProveedor PagoProveedor { get; set; }
        //public int IdPagoProveedor { get; set; }
        public string Fecha { get; set; } = string.Empty;
    }
}
