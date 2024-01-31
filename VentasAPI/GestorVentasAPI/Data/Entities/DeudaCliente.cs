using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentasAPI.Data.Entities
{
    public class DeudaCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Status { get; set; }
        public decimal MontoDeuda { get; set; } // Monto acumulado por ventas

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
        public int IdCliente { get; set; }
    }
}
