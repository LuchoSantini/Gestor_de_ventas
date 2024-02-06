using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlujoFondos_IngresoClientes_IngresoClienteId",
                table: "FlujoFondos");

            migrationBuilder.DropForeignKey(
                name: "FK_FlujoFondos_PagoProveedores_PagoProveedorId",
                table: "FlujoFondos");

            migrationBuilder.DropIndex(
                name: "IX_FlujoFondos_IngresoClienteId",
                table: "FlujoFondos");

            migrationBuilder.DropIndex(
                name: "IX_FlujoFondos_PagoProveedorId",
                table: "FlujoFondos");

            migrationBuilder.DropColumn(
                name: "IngresoClienteId",
                table: "FlujoFondos");

            migrationBuilder.DropColumn(
                name: "PagoProveedorId",
                table: "FlujoFondos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngresoClienteId",
                table: "FlujoFondos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PagoProveedorId",
                table: "FlujoFondos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlujoFondos_IngresoClienteId",
                table: "FlujoFondos",
                column: "IngresoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoFondos_PagoProveedorId",
                table: "FlujoFondos",
                column: "PagoProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlujoFondos_IngresoClientes_IngresoClienteId",
                table: "FlujoFondos",
                column: "IngresoClienteId",
                principalTable: "IngresoClientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlujoFondos_PagoProveedores_PagoProveedorId",
                table: "FlujoFondos",
                column: "PagoProveedorId",
                principalTable: "PagoProveedores",
                principalColumn: "Id");
        }
    }
}
