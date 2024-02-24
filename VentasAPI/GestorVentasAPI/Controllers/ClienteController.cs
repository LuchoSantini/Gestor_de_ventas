using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Implementations;
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
        public IActionResult AgregarCliente([FromBody] ClienteDTO clienteDTO)
        {
            if (_clienteService.CrearCliente(clienteDTO))
            {
                return Ok($"Cliente generado correctamente");
            }
            return BadRequest("Ya existe este cliente");
        }

        [HttpPut("Cancelar Deuda")]
        public IActionResult CancelarDeuda(int idDeuda)
        {
            if (_deudaClienteService.CancelarDeudaCompleta(idDeuda))
            {
                return Ok("Deuda cancelada y cobrada");
            }
            return BadRequest("Deuda no encontrada");
        }

        [HttpPut("Editar Cliente")]
        public IActionResult EditarCliente(ClienteAEditarDTO clienteAEditarDTO)
        {
            if (_clienteService.EditarCliente(clienteAEditarDTO))
            {
                return Ok("Cliente editado exitosamente.");
            }
            return BadRequest("No se encontró el cliente.");
        }

        [HttpPut("Dar de alta un cliente")]
        public IActionResult DarDeAlta(int idCliente)
        {
            if (_clienteService.DarDeAltaCliente(idCliente))
            {
                return Ok("Se dió de alta el cliente.");
            }
            return BadRequest("No se encontró el cliente.");
        }

        [HttpDelete("Dar de baja un cliente")]
        public IActionResult DarDeBaja(int idCliente)
        {
            if (_clienteService.DarDeBajaCliente(idCliente))
            {
                return Ok("Se dió de baja el cliente.");
            }
            return BadRequest("No se encontró el cliente.");
        }
    }
}
