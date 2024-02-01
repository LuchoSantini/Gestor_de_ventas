using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlujoFondos_Clientes_IdCliente",
                table: "FlujoFondos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlujoFondos",
                table: "FlujoFondos");

            migrationBuilder.RenameTable(
                name: "FlujoFondos",
                newName: "IngresoClientes");

            migrationBuilder.RenameIndex(
                name: "IX_FlujoFondos_IdCliente",
                table: "IngresoClientes",
                newName: "IX_IngresoClientes_IdCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngresoClientes",
                table: "IngresoClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngresoClientes_Clientes_IdCliente",
                table: "IngresoClientes",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngresoClientes_Clientes_IdCliente",
                table: "IngresoClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngresoClientes",
                table: "IngresoClientes");

            migrationBuilder.RenameTable(
                name: "IngresoClientes",
                newName: "FlujoFondos");

            migrationBuilder.RenameIndex(
                name: "IX_IngresoClientes_IdCliente",
                table: "FlujoFondos",
                newName: "IX_FlujoFondos_IdCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlujoFondos",
                table: "FlujoFondos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlujoFondos_Clientes_IdCliente",
                table: "FlujoFondos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
