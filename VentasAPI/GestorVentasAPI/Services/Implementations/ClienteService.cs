using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
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

        public bool CrearCliente(ClienteDTO clienteDTO)
        {
            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            Cliente clienteExistente = _context.Clientes.FirstOrDefault(c => c.Nombre == clienteDTO.Nombre && c.Apellido == clienteDTO.Apellido);

            if (clienteExistente == null)
            {
                var nuevoCliente = new Cliente()
                {
                    Nombre = clienteDTO.Nombre,
                    Apellido = clienteDTO.Apellido,
                    Barrio = clienteDTO.Barrio,
                    Descripcion = clienteDTO.Descripcion,
                    Estado = EstadoUsuario.Alta,
                    Tipo = "Cliente",
                    FechaCreacion = fechaFormateada
                };

                _context.Clientes.Add(nuevoCliente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool EditarCliente(ClienteAEditarDTO clienteAEditarDTO)
        {
            Cliente clienteAEditar = _context.Clientes.FirstOrDefault(c => c.Id == clienteAEditarDTO.Id);

            if (clienteAEditar != null)
            {
                clienteAEditar.Nombre = clienteAEditarDTO.Nombre;
                clienteAEditar.Apellido = clienteAEditarDTO.Apellido;
                clienteAEditar.Descripcion = clienteAEditarDTO.Descripcion;
                clienteAEditar.Barrio = clienteAEditarDTO.Barrio;

                _context.Clientes.Update(clienteAEditar);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DarDeAltaCliente(int idCliente)
        {
            Cliente clienteADarDeAlta = _context.Clientes.FirstOrDefault(p => p.Id == idCliente);

            if (clienteADarDeAlta != null)
            {
                clienteADarDeAlta.Estado = EstadoUsuario.Alta;
                _context.Clientes.Update(clienteADarDeAlta);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DarDeBajaCliente(int idCliente)
        {
            Cliente clienteAEliminar = _context.Clientes.FirstOrDefault(p => p.Id == idCliente);

            if (clienteAEliminar != null)
            {
                clienteAEliminar.Estado = EstadoUsuario.Baja;
                _context.Clientes.Update(clienteAEliminar);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        
    }
}
