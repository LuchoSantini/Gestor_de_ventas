using GestorVentasAPI.Enums;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentasAPI.Controllers
{
    public class DeudaClienteController : Controller
    {
        private readonly IDeudaClienteService _deudaClienteService;
        private readonly IFlujoFondoService _flujoFondoService;
        public DeudaClienteController(IDeudaClienteService deudaClienteService, IFlujoFondoService flujoFondoService)
        {
            _deudaClienteService = deudaClienteService;
            _flujoFondoService = flujoFondoService;
        }

        [HttpPut("Cancelar Deuda")]
        public IActionResult CancelarDeuda(int idDeuda)
        {
            _deudaClienteService.CancelarDeudaCompleta(idDeuda);
            //_flujoFondoService.ProcesarFlujoFondos();
            return Ok("Deuda cancelada y cobrada");
        }
    }
}
