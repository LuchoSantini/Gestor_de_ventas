using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestorVentasAPI.Services.Implementations
{
    public class DeudaClienteService : IDeudaClienteService
    {
        private readonly VentasContext _context;
        public DeudaClienteService(VentasContext context)
        {
            _context = context;
        }

        public Venta GetVentasPorId(int id)
        {
            return _context.Ventas
                .FirstOrDefault(x => x.Id == id);
        }

        public DeudaCliente AgregarDeuda(int idVenta)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.Id == idVenta);

            if (venta == null)
            {
                return null;
            }

            // Verificar si ya existe una deuda para la venta
            var deudaExistente = _context.DeudaClientes.FirstOrDefault(dc => dc.IdVenta == idVenta);

            if (venta.Estado == EstadoVenta.Pendiente && deudaExistente == null)
            {
                var nuevaDeuda = new DeudaCliente
                {
                    IdVenta = idVenta,
                    IdCliente = venta.IdCliente,
                    MontoDeuda = venta.MontoVentas,
                    Estado = EstadoVenta.Pendiente,
                };

                _context.DeudaClientes.Add(nuevaDeuda);
                _context.SaveChanges();
                return nuevaDeuda;
            }
            else
            {
                return null;
            }
        }

        public void CancelarDeudaCompleta(int idDeuda)
        {
            DeudaCliente deudaACancelar = _context.DeudaClientes.FirstOrDefault(dc => dc.Id == idDeuda);
            

            if (deudaACancelar != null && deudaACancelar.Estado != EstadoVenta.Cobrada)
            {
                // Actualizar la deuda a cobrada

                var nuevoFlujoFondo = new IngresoCliente
                {
                    Ingresos = deudaACancelar.MontoDeuda,
                    IdCliente = deudaACancelar.IdCliente,
                    MontoFinal = deudaACancelar.MontoDeuda
                };

                deudaACancelar.MontoDeuda = 0;
                deudaACancelar.Estado = EstadoVenta.Cobrada;

                _context.Update(deudaACancelar);
                _context.Add(nuevoFlujoFondo);

                _context.SaveChanges();
            }
        }
    }
}

