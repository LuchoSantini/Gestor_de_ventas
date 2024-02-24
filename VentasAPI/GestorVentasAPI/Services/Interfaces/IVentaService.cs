using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IVentaService
    {
        public Venta AgregarOrden(VentaDTO ventaDTO);
        public bool AgregarProductoOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO);
        public List<Venta> TraerVentas();
        public Venta GetVentaPorId(int id);
        public bool EditarOrdenDeVenta(OrdenDeVentaAEditarDTO ordenDeVentaAEditarDTO);
    }
}
