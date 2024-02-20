using GestorVentasAPI.Context;
using GestorVentasAPI.Data.Entities;
using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Enums;
using GestorVentasAPI.Services.Interfaces;
using System.Diagnostics.Eventing.Reader;

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
            return _context.Proveedores.Where(p => p.Estado == EstadoUsuario.Alta).ToList();
        }
        // Get PagoProveedores
        public List<PagoProveedor> GetPagoProveedores()
        {
            return _context.PagoProveedores.ToList();
        }
        // Editar Proveedor
        public bool EditarProveedor(ProveedorAEditarDTO proveedorAEditarDTO)
        {
            // Buscar el proveedor en la base de datos
            Proveedor proveedorAEditar = _context.Proveedores.FirstOrDefault(p => p.Id == proveedorAEditarDTO.Id);

            if (proveedorAEditar != null)
            {
                proveedorAEditar.Nombre = proveedorAEditarDTO.Nombre;
                proveedorAEditar.Apellido = proveedorAEditarDTO.Apellido;
                proveedorAEditar.Descripcion = proveedorAEditarDTO.Descripcion;

                _context.Update(proveedorAEditar);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        // Eliminar Proveedor
        public void EliminarProveedor(int idProveedor)
        {
            Proveedor proveedorAEliminar = _context.Proveedores.FirstOrDefault(p => p.Id == idProveedor);
            proveedorAEliminar.Estado = EstadoUsuario.Baja;
            _context.Update(proveedorAEliminar);
            _context.SaveChanges();
        }
        // Dar de alta a un Proveedor
        public void DarDeAlta(int idProveedor)
        {
            Proveedor proveedorADarDeAlta = _context.Proveedores.FirstOrDefault(p => p.Id == idProveedor);
            proveedorADarDeAlta.Estado = EstadoUsuario.Alta;
            _context.Update(proveedorADarDeAlta);
            _context.SaveChanges();
        }
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
        // Validar si el proveedor existe en la base de datos
        public bool ValidarExistenciaProveedor(ProveedorDTO proveedorDTO)
        {
            var proveedorExistente = _context.Proveedores.FirstOrDefault(p => p.Nombre == proveedorDTO.Nombre && p.Apellido == proveedorDTO.Apellido);

            if (proveedorExistente != null)
            {
                return true; 
            }
            return false;
        }
        // Editar pago: esto modificará el flujo de fondos y tendrá un impacto en la tabla PagoProveedores
        public bool EditarPago(PagoAEditarDTO pagoAEditarDTO)
        {
            PagoProveedor pagoAEditar = _context.PagoProveedores.FirstOrDefault(p => p.Id == pagoAEditarDTO.Id);

            if (pagoAEditar?.Id != null)
            {
                // Calcular la diferencia entre el monto nuevo y el monto anterior del pago
                decimal diferenciaMonto = pagoAEditarDTO.NuevoMonto - pagoAEditar.Pagos;

                // Actualizar el monto del pago
                pagoAEditar.Pagos = pagoAEditarDTO.NuevoMonto;

                // Actualizar el monto final del pago
                pagoAEditar.MontoFinal += diferenciaMonto;

                _context.SaveChanges();
                // Recalcular los montos finales de los pagos asociados al proveedor
                // Releer este bloque
                var pagosProveedor = _context.PagoProveedores.Where(pp => pp.IdProveedor == pagoAEditar.IdProveedor).ToList();
                foreach (var pagoProveedor in pagosProveedor)
                {
                    pagoProveedor.MontoFinal = _context.PagoProveedores
                        .Where(pp => pp.IdProveedor == pagoProveedor.IdProveedor && pp.Id <= pagoProveedor.Id)
                        .Sum(pp => pp.Pagos);
                }
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
