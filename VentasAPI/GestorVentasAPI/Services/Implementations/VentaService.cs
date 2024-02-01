using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
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
                IdCliente = ventaDTO.IdCliente,
                Estado = ventaDTO.Estado,
            };

            _context.Ventas.Add(ordenParaAgregar);
            _context.SaveChanges();
            return ordenParaAgregar;
        }

        public OrdenDeVenta AgregarProductoOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            var producto = _context.Productos
                .FirstOrDefault(p => p.IdProducto == ordenDeVentaDTO.IdProducto);

            var venta = _context.Ventas.FirstOrDefault(o => o.Id == ordenDeVentaDTO.IdVenta && o.IdCliente == ordenDeVentaDTO.IdCliente);

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