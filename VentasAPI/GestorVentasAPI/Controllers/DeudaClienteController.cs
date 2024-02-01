using GestorVentasAPI.Enums;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentasAPI.Controllers
{
    public class DeudaClienteController : Controller
    {
        private readonly IDeudaClienteService _deudaClienteService;
        public DeudaClienteController(IDeudaClienteService deudaClienteService)
        {
            _deudaClienteService = deudaClienteService;
        }

        [HttpPost("Agregar Deuda")]
        public IActionResult AgregarDeuda(int idVenta)
        {
            var deuda = _deudaClienteService.AgregarDeuda(idVenta);

            if(deuda == null)
            {
                return BadRequest("Error: venta cobrada o inexistente");
            }
            return Ok("Deuda agregada");
        }

        [HttpPut("Cancelar Deuda")]
        public IActionResult CancelarDeuda(int idDeuda)
        {
            _deudaClienteService.CancelarDeudaCompleta(idDeuda);
            return Ok("Deuda cancelada y cobrada");
        }
    }
}
