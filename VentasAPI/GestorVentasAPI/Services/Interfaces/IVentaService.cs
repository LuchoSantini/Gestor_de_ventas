using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IVentaService
    {
        public Venta AgregarOrden(VentaDTO ventaDTO);
        public OrdenDeVenta AgregarProductoOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO);
    }
}
