using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedors",
                table: "Proveedors");

            migrationBuilder.RenameTable(
                name: "Proveedors",
                newName: "Proveedores");

            migrationBuilder.RenameColumn(
                name: "IngresosClientes",
                table: "IngresoClientes",
                newName: "Ingresos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedors");

            migrationBuilder.RenameColumn(
                name: "Ingresos",
                table: "IngresoClientes",
                newName: "IngresosClientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedors",
                table: "Proveedors",
                column: "Id");
        }
    }
}
