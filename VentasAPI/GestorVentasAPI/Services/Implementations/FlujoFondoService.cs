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

        public void ProcesarFlujoFondos()
        {
            IngresoCliente montoFinalIngresos = _context.IngresoClientes.OrderBy(ic => ic.Id).LastOrDefault();
            PagoProveedor montoFinalProveedor = _context.PagoProveedores.OrderBy(pp => pp.Id).LastOrDefault();

            decimal montoIngresos = montoFinalIngresos.MontoFinal;
            decimal montoPagos = montoFinalProveedor.MontoFinal;
            decimal montoFinal = montoIngresos - montoPagos;

            /*
             Editar esto de la siguiente maner para calcular el monto final:
              Corregir: el metodo para calcular el monto final esta mal y es un test.
                No se debe tomar el ultimo ingreso o el ultimo pago.
                Tomar datos por ID.
                Agregar a FlujoFondos las columnas de montoFinal de ingresos y de pagos, dejar las de
                ingresos y de pagos. 
                El monto final sera la resta de sumatoria de la columna de MontoFinalIngresos y PagoProveedores 
                Sumatoria MontoFinalIngresos - Sumatoria PagoProveedores = montoFinal3
             */

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            var flujoFondos = new FlujoFondo
            {
                    Ingresos = montoIngresos,
                    Pagos = montoPagos,
                    SaldoFinal = montoFinal,
                    FechaActualizacion = fechaFormateada
            };
            _context.FlujoFondos.Add(flujoFondos);
            _context.SaveChanges();
        }
    }
}
