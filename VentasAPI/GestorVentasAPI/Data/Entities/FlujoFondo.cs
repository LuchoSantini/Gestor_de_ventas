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
        public decimal Ingresos { get; set; }
        public decimal Pagos { get; set; }
        public decimal SaldoFinal { get; set; }
    }
}
