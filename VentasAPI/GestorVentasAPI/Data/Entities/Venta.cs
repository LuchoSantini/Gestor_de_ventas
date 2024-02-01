using GestorVentasAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentasAPI.Data.Entities
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public EstadoVenta Estado { get; set; }
        public decimal MontoVentas { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
        public int IdCliente { get; set; }
        public ICollection<OrdenDeVenta> OrdenDeVentas { get; set; } = new List<OrdenDeVenta>();
    }
}
