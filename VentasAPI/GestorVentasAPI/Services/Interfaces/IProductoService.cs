using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IProductoService
    {
        public Producto AgregarProducto(ProductoDTO productoDTO);
    }
}
