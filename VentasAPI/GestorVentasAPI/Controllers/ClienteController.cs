using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace GestorVentasAPI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IDeudaClienteService _deudaClienteService;
        public ClienteController(IClienteService clienteService, IDeudaClienteService deudaClienteService)
        {
            _clienteService = clienteService;
            _deudaClienteService = deudaClienteService;
        }

        [HttpPost("Agregar Cliente")]
        public IActionResult AgregarCliente([FromBody] ClienteDTO dto)
        {
            _clienteService.CrearCliente(dto);
            return Ok(dto);
        }

        [HttpPut("Cancelar Deuda")]
        public IActionResult CancelarDeuda(int idDeuda)
        {
            _deudaClienteService.CancelarDeudaCompleta(idDeuda);
            return Ok("Deuda cancelada y cobrada");
        }
    }
}
