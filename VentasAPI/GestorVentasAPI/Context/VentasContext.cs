using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System;
using GestorVentasAPI.Data.Entities;

namespace GestorVentasAPI.Context
{
    public class VentasContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DeudaCliente> DeudaClientes { get; set; }
        public DbSet<FlujoFondo> FlujoFondos { get; set; }
        public DbSet<OrdenDeVenta> OrdenDeVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Venta> Ventas { get; set; }


        public VentasContext(DbContextOptions<VentasContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.DeudaClientes)
                .WithOne()
                .HasForeignKey(dc => dc.IdCliente);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<OrdenDeVenta>()
                .HasOne(odv => odv.Producto)
                .WithMany()
                .HasForeignKey(odv => odv.IdProducto);

            modelBuilder.Entity<Venta>()
                .HasMany(v => v.OrdenDeVentas)
                .WithOne()
                .HasForeignKey(odv => odv.IdVenta);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<FlujoFondo>()
                .HasOne(ff => ff.Cliente)
                .WithMany()
                .HasForeignKey(ff => ff.IdCliente);

            modelBuilder.Entity<FlujoFondo>()
                .HasOne(ff => ff.Proveedor)
                .WithMany()
                .HasForeignKey(ff => ff.IdProveedor);
        }
    }
}

