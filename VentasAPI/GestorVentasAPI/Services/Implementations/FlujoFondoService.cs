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
            IngresoCliente tablaIngresos = _context.IngresoClientes.OrderBy(ic => ic.Id).LastOrDefault();
            PagoProveedor tablaPagos = _context.PagoProveedores.OrderBy(pp => pp.Id).LastOrDefault();

            decimal ingresos = tablaIngresos.Ingresos;
            decimal pagos = tablaPagos.Pagos;
            decimal montoIngresos = tablaIngresos.MontoFinal;
            decimal montoPagos = tablaPagos.MontoFinal;
            decimal montoFinal = montoIngresos - montoPagos;

            /*
             Editar esto de la siguiente maner para calcular el monto final:
              Corregir: el metodo para calcular el monto final esta mal y es un test.
                No se debe tomar el ultimo ingreso o el ultimo pago.
                Tomar datos por ID.
                Agregar a FlujoFondos las columnas de montoFinal de ingresos y de pagos, dejar las de
                ingresos y de pagos. 
             */

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            var flujoFondosIng = new FlujoFondo
            {
                    Ingresoos = ingresos,
                    MontoFinalIngresos = montoIngresos,
                    SaldoFinal = montoFinal,
                    FechaActualizacion = fechaFormateada
            };

            var flujoFondosPag = new FlujoFondo
            {
                    Pagos = pagos,
                    MontoFinalPagos = montoPagos,
                    SaldoFinal = montoFinal,
                    FechaActualizacion = fechaFormateada
            };

            _context.FlujoFondos.Add(flujoFondosIng);
            _context.FlujoFondos.Add(flujoFondosPag);
            _context.SaveChanges();
        }
    }
}
