using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace GestorVentasAPI.Services.Implementations
{
    public class FlujoFondosService : IFlujoFondoService
    {
        private readonly VentasContext _context;
        public FlujoFondosService(VentasContext context)
        {
            _context = context;
        }

        public void ProcesarFlujoFondoIngresos()
        {
            IngresoCliente ingresos = _context.IngresoClientes.OrderByDescending(ic => ic.Id).FirstOrDefault();

            decimal montoAnterior = _context.FlujoFondos
                    .OrderByDescending(ic => ic.Id)
                    .Select(ic => ic.MontoFinal)
                    .FirstOrDefault();

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            if (ingresos != null)
            {

                var flujoFondoIngresos = new FlujoFondo
                {
                    Monto = ingresos.Ingresos,
                    Tipo = "Ingreso",
                    Fecha = fechaFormateada
                };

                if (flujoFondoIngresos.Tipo == "Ingreso" || flujoFondoIngresos.Tipo == "Ingreso por deuda")
                {
                    decimal nuevoMontoFinal = montoAnterior + ingresos.Ingresos;
                    flujoFondoIngresos.MontoFinal = nuevoMontoFinal;
                }

                _context.FlujoFondos.Add(flujoFondoIngresos);
                _context.SaveChanges();
            }
        }

        public void ProcesarFlujoFondoPagos()
        {
            PagoProveedor pagos = _context.PagoProveedores.OrderByDescending(pp => pp.Id).FirstOrDefault();

            decimal montoAnterior = _context.FlujoFondos
                    .OrderByDescending(ic => ic.Id)
                    .Select(ic => ic.MontoFinal)
                    .FirstOrDefault();
            
            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            if (pagos != null) 
            {
                var flujoFondoPagos = new FlujoFondo
                {
                    Monto = pagos.Pagos,
                    Tipo = "Pago",
                    Fecha = fechaFormateada
                };

                if (flujoFondoPagos.Tipo == "Pago")
                {
                    decimal nuevoMontoFinal = montoAnterior - flujoFondoPagos.Monto;
                    flujoFondoPagos.MontoFinal = nuevoMontoFinal;
                }
                _context.FlujoFondos.Add(flujoFondoPagos);
                _context.SaveChanges();
            }
        }
    }
}
