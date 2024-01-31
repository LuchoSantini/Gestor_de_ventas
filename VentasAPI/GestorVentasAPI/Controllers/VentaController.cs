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
        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
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
            _ventaService.AgregarProductoOrdenDeVenta(ordenDeVentaDTO);
            return Ok(ordenDeVentaDTO);
        }
    }
}
