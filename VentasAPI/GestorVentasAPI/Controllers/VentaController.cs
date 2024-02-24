using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentasAPI.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService _ventaService;
        private readonly IFlujoFondoService _flujoFondoService;
        public VentaController(IVentaService ventaService, IFlujoFondoService flujoFondoService)
        {
            _ventaService = ventaService;
            _flujoFondoService = flujoFondoService;
        }

        [HttpPost("Agregar Orden de Venta")]
        public IActionResult AgregarOrdenDeVenta([FromBody] VentaDTO ventaDto)
        {
            var nuevaOrden = _ventaService.AgregarOrden(ventaDto);
            return Ok($"Se agregó la orden n° {nuevaOrden.Id}");
        }

        [HttpPost("Agregar productos a la Orden de Venta")]
        public IActionResult AgregarProductosOrdenDeVenta([FromBody] OrdenDeVentaDTO ordenDeVentaDTO)
        {
            if (_ventaService.AgregarProductoOrdenDeVenta(ordenDeVentaDTO))
            {
                return Ok($"Productos agregados correctamente");
            }
            return BadRequest("No se encontró la Venta o el Producto");
        }

        [HttpPut("Editar Orden de Venta")]
        public IActionResult EditarOrdenDeVenta([FromBody] OrdenDeVentaAEditarDTO ordenDeVentaAEditarDTO)
        {
            if (_ventaService.EditarOrdenDeVenta(ordenDeVentaAEditarDTO))
            {
                return Ok($"Se editó la Orden de Venta con el siguiente ID: {ordenDeVentaAEditarDTO.Id}");
            }
            return BadRequest("Orden de Venta no encontrado");
        }

        [HttpGet("Traer Ventas")]
        public IActionResult TraerVentas()
        {
            return Ok(_ventaService.TraerVentas());
        }
    }
}
