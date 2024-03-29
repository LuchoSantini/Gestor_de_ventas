﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestorVentasAPI.Enums;

namespace GestorVentasAPI.Data.Entities
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public EstadoUsuario Estado { get; set; }
        public string FechaCreacion { get; set; } = string.Empty;
        public ICollection<DeudaCliente> DeudaClientes { get; set; } = new List<DeudaCliente>();
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
