using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorVentasAPI.Data.Entities
{
    public class IngresoCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal MontoFinal { get; set; }
        // Agregar la prop fecha para que la tabla tenga sentido
    }
}
