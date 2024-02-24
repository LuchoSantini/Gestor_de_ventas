using System.Text.Json.Serialization;

namespace GestorVentasAPI.Data.Models
{
    public class OrdenDeVentaAEditarDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
