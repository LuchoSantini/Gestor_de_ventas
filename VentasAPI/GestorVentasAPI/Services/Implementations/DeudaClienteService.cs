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

        public bool CancelarDeudaCompleta(int idDeuda)
        {
            DeudaCliente deudaACancelar = _context.DeudaClientes.FirstOrDefault(dc => dc.Id == idDeuda);
            Venta ventaACobrar = _context.Ventas.FirstOrDefault(v => v.Id == deudaACancelar.IdVenta);

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            if (deudaACancelar != null && deudaACancelar.Estado != EstadoVenta.Cobrada && ventaACobrar != null)
            {
                // Calculo del nuevo MontoFinal
                decimal montoAnterior = _context.IngresoClientes
                    .Where(ic => ic.IdCliente == deudaACancelar.IdCliente)
                    .OrderByDescending(ic => ic.Id)
                    .Select(ic => ic.MontoFinal)
                    .FirstOrDefault();

                decimal nuevoMontoFinal = montoAnterior + deudaACancelar.MontoDeuda;

                // Actualizar la deuda a cobrada
                var nuevoFlujoFondoDeudaCancelada = new IngresoCliente
                {
                    Ingresos = deudaACancelar.MontoDeuda,
                    IdCliente = deudaACancelar.IdCliente,
                    MontoFinal = nuevoMontoFinal,
                    FechaIngreso = fechaFormateada
                };

                ventaACobrar.MontoVentas = deudaACancelar.MontoDeuda;
                deudaACancelar.MontoDeuda = 0;
                deudaACancelar.Estado = EstadoVenta.Cobrada;
                ventaACobrar.Estado = EstadoVenta.Cobrada;

                _context.Ventas.Update(ventaACobrar);
                _context.DeudaClientes.Update(deudaACancelar);
                _context.IngresoClientes.Add(nuevoFlujoFondoDeudaCancelada);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}

