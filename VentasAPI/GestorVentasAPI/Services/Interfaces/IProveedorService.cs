using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IProveedorService
    {
        public Proveedor AgregarProveedor(ProveedorDTO proveedorDTO);
        public PagoProveedor AgregarPago(PagoProveedorDTO pagoProveedorDTO);
        public List<PagoProveedor> GetPagoProveedores();
        public List<Proveedor> GetProveedores();
    }
}
