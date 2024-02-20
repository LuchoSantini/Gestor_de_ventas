namespace GestorVentasAPI.Data.Models
{
    public class ProveedorAEditarDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
