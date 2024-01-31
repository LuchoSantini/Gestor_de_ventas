﻿// <auto-generated />
using System;
using GestorVentasAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    [DbContext(typeof(VentasContext))]
    [Migration("20240131210622_mig4-typeErrorsFixed")]
    partial class mig4typeErrorsFixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.DeudaCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MontoDeuda")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("IdCliente");

                    b.ToTable("DeudaClientes");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.FlujoFondo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("IngresosClientes")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MontoFinal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PagoProveedores")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdProveedor");

                    b.ToTable("FlujoFondos");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.OrdenDeVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdVenta")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("OrdenDeVentas");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Calibre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Proveedors");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MontoVentas")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.DeudaCliente", b =>
                {
                    b.HasOne("GestorVentasAPI.Data.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("GestorVentasAPI.Data.Entities.Cliente", null)
                        .WithMany("DeudaClientes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.FlujoFondo", b =>
                {
                    b.HasOne("GestorVentasAPI.Data.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorVentasAPI.Data.Entities.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.OrdenDeVenta", b =>
                {
                    b.HasOne("GestorVentasAPI.Data.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorVentasAPI.Data.Entities.Venta", null)
                        .WithMany("OrdenDeVentas")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Venta", b =>
                {
                    b.HasOne("GestorVentasAPI.Data.Entities.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Cliente", b =>
                {
                    b.Navigation("DeudaClientes");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("GestorVentasAPI.Data.Entities.Venta", b =>
                {
                    b.Navigation("OrdenDeVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
