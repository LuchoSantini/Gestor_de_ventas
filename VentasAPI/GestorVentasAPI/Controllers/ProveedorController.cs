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
            if (_proveedorService.ValidarExistenciaProveedor(proveedorDTO))
            {
                return BadRequest("El proveedor ya existe en la base de datos.");
            }
            _proveedorService.AgregarProveedor(proveedorDTO);
            return Ok("Proveedor agregado exitosamente");
        }

        [HttpPut("Editar Proveedor")]
        public IActionResult EditarProveedor([FromBody] ProveedorAEditarDTO proveedorAEditarDTO)
        {
            if (_proveedorService.EditarProveedor(proveedorAEditarDTO))
            {
                return Ok($"Se editó el Proveedor con el siguiente ID: {proveedorAEditarDTO.Id}");
            }
            return BadRequest("Proveedor no encontrado");
        }

        [HttpDelete("Eliminar Proveedor")]
        public IActionResult EliminarProveedor(int idProveedor)
        {
            _proveedorService.EliminarProveedor(idProveedor);
            return Ok();
        }
        [HttpPut("Dar de alta Proveedor")]
        public IActionResult DarDeAlta(int idProveedor)
        {
            _proveedorService.DarDeAlta(idProveedor);
            return Ok();
        }

        [HttpGet("Traer Proveedores")]
        public IActionResult GetProveedores()
        {
            var pagos = _proveedorService.GetProveedores();
            return Ok(pagos);
        }

        [HttpPost("Agregar Pago")]
        public IActionResult AgregarPago([FromBody] PagoProveedorDTO pagoProveedorDTO)
        {
            _proveedorService.AgregarPago(pagoProveedorDTO);
            return Ok(pagoProveedorDTO);
        }

        [HttpPut("Editar Pago")]
        public IActionResult EditarPago([FromBody] PagoAEditarDTO pagoAEditarDTO)
        {
            if(_proveedorService.EditarPago(pagoAEditarDTO))
            {
                return Ok($"Se editó el pago con el siguiente ID: {pagoAEditarDTO.Id}");
            }
            return BadRequest("Pago no encontrado");
        }
    }
}
