using GestorVentasAPI.Data.Entities;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IDeudaClienteService
    {
        public bool CancelarDeudaCompleta(int idDeuda);
    }
}
