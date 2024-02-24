using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IProductoService
    {
        public bool AgregarProducto(ProductoDTO productoDTO);
        public bool EditarProducto(ProductoDTO productoDTO);
        public void EliminarProducto(int idProducto);
        public void DarDeAltaProducto(int idProducto);
        public List<Producto> TraerProductos();
    }
}
