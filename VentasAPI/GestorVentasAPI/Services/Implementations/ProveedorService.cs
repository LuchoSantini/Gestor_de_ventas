using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
using GestorVentasAPI.Services.Interfaces;

namespace GestorVentasAPI.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly VentasContext _context;
        public ProveedorService(VentasContext context)
        {
            _context = context;
        }

        // Agregar Proveedor
        public Proveedor AgregarProveedor(ProveedorDTO proveedorDTO)
        {
            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");
            var nuevoProveedor = new Proveedor
            {
                Nombre = proveedorDTO.Nombre,
                Apellido = proveedorDTO.Apellido,
                Descripcion = proveedorDTO.Descripcion,
                Estado = EstadoUsuario.Alta, // Siempre que se agregue un proveedor va a estar de alta
                FechaCreacion = fechaFormateada
            };
            _context.Proveedores.Add(nuevoProveedor);
            _context.SaveChanges();
            return nuevoProveedor;
        }

        // Get Proveedores
        public List<Proveedor> GetProveedores()
        {
            return _context.Proveedores.ToList();
        }
        // Get PagoProveedores
        public List<PagoProveedor> GetPagoProveedores()
        {
            return _context.PagoProveedores.ToList();
        }

        // Editar Proveedor

        // Eliminar Proveedor

        // Agregar un pago a un Proveedor
        public PagoProveedor AgregarPago(PagoProveedorDTO pagoProveedorDTO)
        {
            Proveedor proveedor = _context.Proveedores.FirstOrDefault(p => p.Id == pagoProveedorDTO.IdProveedor);

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("dd/MM/yyyy HH:mm");

            decimal montoAnterior = _context.PagoProveedores
                .Where(pp => pp.IdProveedor == proveedor.Id)
                .OrderByDescending(pp => pp.Id)
                .Select(pp => pp.MontoFinal)
                .FirstOrDefault();

            if (proveedor != null)
            {
                decimal nuevoMontoFinal = montoAnterior + pagoProveedorDTO.MontoAPagar;
                var nuevoPago = new PagoProveedor
                {
                    IdProveedor = proveedor.Id,
                    Pagos = pagoProveedorDTO.MontoAPagar,
                    MontoFinal = nuevoMontoFinal,
                    FechaPago = fechaFormateada
                };
                _context.PagoProveedores.Add(nuevoPago);
                _context.SaveChanges();
                return nuevoPago;
            }
            else return null;
        }
    }
}
