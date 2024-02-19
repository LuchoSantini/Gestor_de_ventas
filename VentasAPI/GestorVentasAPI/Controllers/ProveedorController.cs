using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentasAPI.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedorService;
        private readonly IFlujoFondoService _flujoFondoService;
        public ProveedorController(IProveedorService proveedorService, IFlujoFondoService flujoFondoService)
        {
            _proveedorService = proveedorService;
            _flujoFondoService = flujoFondoService;
        }

        [HttpPost("Agregar Proveedor")]
        public IActionResult AgregarProveedor([FromBody] ProveedorDTO proveedorDTO)
        {
            _proveedorService.AgregarProveedor(proveedorDTO);
            return Ok(proveedorDTO);
        }

        [HttpPost("Agregar Pago")]
        public IActionResult AgregarPago([FromBody] PagoProveedorDTO pagoProveedorDTO)
        {
            _proveedorService.AgregarPago(pagoProveedorDTO);
            //_flujoFondoService.ProcesarFlujoFondos();
            return Ok(pagoProveedorDTO);
        }

        [HttpGet("Get Proveedores")]
        public IActionResult GetProveedores()
        {
            var pagos = _proveedorService.GetProveedores();
            return Ok(pagos);
        }
    }
}
