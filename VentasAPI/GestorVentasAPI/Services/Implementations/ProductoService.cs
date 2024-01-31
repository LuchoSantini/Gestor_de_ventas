using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Interfaces;
using System;

namespace GestorVentasAPI.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly VentasContext _context;

        public ProductoService(VentasContext context)
        {
            _context = context;
        }

        public Producto AgregarProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Calibre = productoDTO.Calibre,
                Descripcion = productoDTO.Descripcion,
                Precio = productoDTO.Precio,
                Status = true,
            };
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto;
        }
    }
}
