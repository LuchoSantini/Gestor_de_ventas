using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Interfaces;
using System;

namespace GestorVentasAPI.Services.Implementations
{
    public class ClienteService : IClienteService

    {
        private readonly VentasContext _context;
        public ClienteService(VentasContext context)
        {
            _context = context;
        }

        public Cliente CrearCliente(ClienteDTO dto)
        {
            var cliente = new Cliente()
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Barrio = dto.Barrio,
                Descripcion = dto.Descripcion,
                Tipo = "Cliente"
            };

            _context.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}
