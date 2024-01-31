using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestorVentasAPI.Services.Implementations
{
    public class VentaService : IVentaService
    {
        private readonly VentasContext _context;
        public VentaService(VentasContext context)
        {
            _context = context;
        }

        public Venta AgregarOrden(VentaDTO ventaDTO)
        {
            var ordenParaAgregar = new Venta
            {
                //Id = orderDto.Id,
                IdCliente = ventaDTO.IdCliente,
                Status = ventaDTO.Status,
            };

            _context.Ventas.Add(ordenParaAgregar);
            _context.SaveChanges();
            return ordenParaAgregar;
        }

        public OrdenDeVenta AgregarProductoOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            //var userExists = _context.Users.Any(u => u.UserId == orderLineDto.UserId);
            //var productExists = _context.Products.Any(p => p.ProductId == orderLineDto.ProductId);

            //if (!userExists || !productExists)
            //{
            //    return null;
            //}

            var producto = _context.Productos
                .FirstOrDefault(p => p.IdProducto == ordenDeVentaDTO.IdProducto);

            var venta = _context.Ventas.FirstOrDefault(o => o.Id == ordenDeVentaDTO.IdVenta && o.IdCliente == ordenDeVentaDTO.IdCliente);

            //if (product != null)
            //{
            //    var selectedColour = product.Colours.FirstOrDefault(c => c.Id == orderLineDto.ColourId);
            //    var selectedSize = product.Sizes.FirstOrDefault(s => s.Id == orderLineDto.SizeId);

            //    if (selectedColour == null || selectedSize == null)
            //    {
            //        return null;
            //    }

            //    var order = _context.Orders.FirstOrDefault(o => o.Id == orderLineDto.OrderId && o.UserId == orderLineDto.UserId);

            //    if (order == null)
            //    {
            //        return null;
            //    }

            var nuevaOrdenDeVenta = new OrdenDeVenta
            {
                IdVenta = ordenDeVentaDTO.IdVenta,
                Producto = producto,
                Cantidad = ordenDeVentaDTO.Cantidad,
            };

            decimal montoTotalVenta = nuevaOrdenDeVenta.Cantidad * producto.Precio;
            venta.MontoVentas += montoTotalVenta;

            _context.OrdenDeVentas.Add(nuevaOrdenDeVenta);
            _context.SaveChanges();
            return nuevaOrdenDeVenta;
        }
    }
}

