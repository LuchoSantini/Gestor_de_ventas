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


        public void CancelarDeudaCompleta(int idDeuda)
        {
            DeudaCliente deudaACancelar = _context.DeudaClientes.FirstOrDefault(dc => dc.Id == idDeuda);
            Venta ventaACobrar = _context.Ventas.FirstOrDefault(v => v.Id == deudaACancelar.IdVenta);

            if (deudaACancelar != null && deudaACancelar.Estado != EstadoVenta.Cobrada)
            {
                // Actualizar la deuda a cobrada

                var nuevoFlujoFondoDeudaCancelada = new IngresoCliente
                {
                    Ingresos = deudaACancelar.MontoDeuda,
                    IdCliente = deudaACancelar.IdCliente,
                    MontoFinal = deudaACancelar.MontoDeuda
                };

                ventaACobrar.MontoVentas = deudaACancelar.MontoDeuda;
                deudaACancelar.MontoDeuda = 0;
                deudaACancelar.Estado = EstadoVenta.Cobrada;

                _context.DeudaClientes.Update(deudaACancelar);
                _context.IngresoClientes.Add(nuevoFlujoFondoDeudaCancelada);
                _context.SaveChanges();
            }
        }
    }
}

