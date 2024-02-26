using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestorVentasAPI.Services.Implementations
{
    public class DeudaClienteService : IDeudaClienteService
    {
        private readonly VentasContext _context;
        private readonly IFlujoFondoService _flujoFondoService;

        public DeudaClienteService(VentasContext context, IFlujoFondoService flujoFondoService)
        {
            _context = context;
            _flujoFondoService = flujoFondoService;
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
                deudaACancelar.Estado = EstadoVenta.Cobrada;
                ventaACobrar.Estado = EstadoVenta.Cobrada;

                decimal montoAnteriorFlujoFondos = _context.FlujoFondos
                    .OrderByDescending(ic => ic.Id)
                    .Select(ic => ic.MontoFinal)
                    .FirstOrDefault();

                var flujoFondoDeuda = new FlujoFondo
                {
                    Monto = deudaACancelar.MontoDeuda,
                    Tipo = "Ingreso por deuda",
                    Fecha = fechaFormateada
                };

                if (flujoFondoDeuda.Tipo == "Ingreso" || flujoFondoDeuda.Tipo == "Ingreso por deuda")
                {
                    decimal nuevoMonto = montoAnteriorFlujoFondos + flujoFondoDeuda.Monto;
                    flujoFondoDeuda.MontoFinal = nuevoMonto;
                }

                _context.FlujoFondos.Add(flujoFondoDeuda);
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

