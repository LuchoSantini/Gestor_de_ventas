using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IClienteService
    {
        public Cliente CrearCliente(ClienteDTO dto);
    }
}
