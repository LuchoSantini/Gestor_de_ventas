using GestorVentasAPI.Data.Entities;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IDeudaClienteService
    {
        public Venta GetVentasPorId(int id);
        public DeudaCliente AgregarDeuda(int idCliente);
        public void CancelarDeudaCompleta(int idDeuda);
    }
}
