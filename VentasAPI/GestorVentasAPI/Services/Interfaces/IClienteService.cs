using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IClienteService
    {
        public bool CrearCliente(ClienteDTO clienteDTO);
        public bool EditarCliente(ClienteAEditarDTO clienteAEditarDTO);
        public bool DarDeBajaCliente(int idCliente);
        public bool DarDeAltaCliente(int idCliente);
    }
}
