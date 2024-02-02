using GestorVentasAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentasAPI.Data.Entities
{
    public class DeudaCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdCliente")]
        public int IdCliente { get; set; }
        public EstadoVenta Estado { get; set; }
        public decimal MontoDeuda { get; set; } // Monto acumulado por ventas
        public int IdVenta { get; set; }
        
    }
}
