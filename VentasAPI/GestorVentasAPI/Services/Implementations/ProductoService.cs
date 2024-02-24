using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
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

        public bool AgregarProducto(ProductoDTO productoDTO)
        {
            Producto productoExistente = _context.Productos.FirstOrDefault(p => p.Nombre == productoDTO.Nombre && p.Calibre == productoDTO.Calibre);

            // Tener en cuenta agregar una tabla para los Calibres. (Calibre refiere al tamaño del producto en litros o kilos)
            if (productoExistente == null)
            {
                var producto = new Producto
                {
                    Nombre = productoDTO.Nombre,
                    Calibre = productoDTO.Calibre,
                    Descripcion = productoDTO.Descripcion,
                    Precio = productoDTO.Precio,
                    Estado = EstadoProducto.Alta,
                };
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditarProducto(ProductoDTO productoDTO)
        {
            Producto productoAEditar = _context.Productos.FirstOrDefault(p => p.Id == productoDTO.Id);

            if (productoAEditar != null)
            {
                productoAEditar.Nombre = productoDTO.Nombre;
                productoAEditar.Calibre = productoDTO.Calibre;
                productoAEditar.Descripcion = productoDTO.Descripcion;

                _context.Update(productoAEditar);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void EliminarProducto(int idProducto)
        {
            Producto productoAEliminar = _context.Productos.FirstOrDefault(p => p.Id == idProducto);
            productoAEliminar.Estado = EstadoProducto.Baja;
            _context.Update(productoAEliminar);
            _context.SaveChanges();
        }

        public void DarDeAltaProducto(int idProducto)
        {
            Producto productoADarDeAlta = _context.Productos.FirstOrDefault(p => p.Id == idProducto);
            productoADarDeAlta.Estado = EstadoProducto.Alta;
            _context.Update(productoADarDeAlta);
            _context.SaveChanges();
        }

        public List<Producto> TraerProductos()
        {
            var productos = _context.Productos.Where(p => p.Estado == EstadoProducto.Alta).ToList();
            return productos;
        }
    }
}
