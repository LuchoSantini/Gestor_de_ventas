using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestorVentasAPI.Services.Implementations
{
    public class FlujoFondosService : IFlujoFondoService
    {
        private readonly VentasContext _context;
        public FlujoFondosService(VentasContext context)
        {
            _context = context;
        }

        public void ProcesarFlujoFondos(object state)
        {
            IngresoCliente montoFinalIngresos = _context.IngresoClientes.OrderBy(ic => ic.Id).LastOrDefault();
            PagoProveedor montoFinalProveedor = _context.PagoProveedores.OrderBy(pp => pp.Id).LastOrDefault();

            decimal montoIngresos = montoFinalIngresos.MontoFinal;
            decimal montoPagos = montoFinalProveedor.MontoFinal;
            decimal montoFinal = montoIngresos - montoPagos;

            var flujoFondos = new FlujoFondo
                {
                    Ingresos = montoIngresos,
                    Pagos = montoPagos,
                    SaldoFinal = montoFinal
            };
            _context.FlujoFondos.Add(flujoFondos);
            _context.SaveChanges();
        }
    }
}
