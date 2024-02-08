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
            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");
            var ordenParaAgregar = new Venta
            {
                IdCliente = ventaDTO.IdCliente,
                Estado = ventaDTO.Estado,
                FechaVenta = fechaFormateada
            };

            _context.Ventas.Add(ordenParaAgregar);
            _context.SaveChanges();
            return ordenParaAgregar;
        }

        public OrdenDeVenta AgregarProductoOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            var producto = _context.Productos
                .FirstOrDefault(p => p.Id == ordenDeVentaDTO.IdProducto);

            var venta = _context.Ventas.FirstOrDefault(o => o.Id == ordenDeVentaDTO.IdVenta && o.IdCliente == ordenDeVentaDTO.IdCliente);

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            // Acá se asignan valores a la tabla OrdenDeVenta
            var nuevaOrdenDeVenta = new OrdenDeVenta
            {
                IdVenta = ordenDeVentaDTO.IdVenta,
                Producto = producto,
                Cantidad = ordenDeVentaDTO.Cantidad,
                FechaCreacion = fechaFormateada
            };

            // Dependiendo del estado de la Venta generada se añade o no el monto a la tabla IngresoCliente
            decimal montoTotalVenta = nuevaOrdenDeVenta.Cantidad * producto.Precio;

            // Cambio: Obtener el último ingreso del cliente
            decimal montoAnterior = _context.IngresoClientes
                .Where(ic => ic.IdCliente == venta.IdCliente)
                .OrderByDescending(ic => ic.Id)
                .Select(ic => ic.MontoFinal)
                .FirstOrDefault();

            // Calculo del nuevo MontoFinal
            decimal nuevoMontoFinal = montoAnterior + montoTotalVenta;

            if (venta?.Estado == EstadoVenta.Cobrada)
            {
                venta.MontoVentas += montoTotalVenta;

                var nuevoFlujoFondoVenta = new IngresoCliente
                {
                    Ingresos = montoTotalVenta,
                    IdCliente = venta.IdCliente,
                    MontoFinal = nuevoMontoFinal,
                    FechaIngreso = fechaFormateada
                };

                _context.IngresoClientes.Add(nuevoFlujoFondoVenta);
                _context.OrdenDeVentas.Add(nuevaOrdenDeVenta);
            }
            else if (venta?.Estado == EstadoVenta.Pendiente && _context.DeudaClientes.FirstOrDefault(dc => dc.IdVenta == venta.Id) == null)
            {
                var nuevaDeuda = new DeudaCliente
                {
                    IdVenta = venta.Id,
                    IdCliente = venta.IdCliente,
                    MontoDeuda = montoTotalVenta,
                    Estado = EstadoVenta.Pendiente,
                    CreacionDeuda = fechaFormateada
                };
                _context.DeudaClientes.Add(nuevaDeuda);
            }
            _context.SaveChanges();
            return nuevaOrdenDeVenta;
        }
    }
}