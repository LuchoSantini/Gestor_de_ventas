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
            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");
            var cliente = new Cliente()
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Barrio = dto.Barrio,
                Descripcion = dto.Descripcion,
                Tipo = "Cliente",
                FechaCreacion = fechaFormateada
            };

            _context.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

    }
}
