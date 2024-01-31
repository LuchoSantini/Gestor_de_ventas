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
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Agregar Cliente")]
        public IActionResult AgregarCliente([FromBody] ClienteDTO dto)
        {
            _clienteService.CrearCliente(dto);
            return Ok(dto);
        }
    }
}
