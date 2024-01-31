using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig3Bugfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Clientes_ClienteId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Clientes_IdCliente",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "DeudaClientes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Productos",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IdCliente",
                table: "DeudaClientes",
                newName: "IX_DeudaClientes_IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ClienteId",
                table: "DeudaClientes",
                newName: "IX_DeudaClientes_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeudaClientes",
                table: "DeudaClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeudaClientes_Clientes_ClienteId",
                table: "DeudaClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeudaClientes_Clientes_IdCliente",
                table: "DeudaClientes",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeudaClientes_Clientes_ClienteId",
                table: "DeudaClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DeudaClientes_Clientes_IdCliente",
                table: "DeudaClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeudaClientes",
                table: "DeudaClientes");

            migrationBuilder.RenameTable(
                name: "DeudaClientes",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Productos",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_DeudaClientes_IdCliente",
                table: "Products",
                newName: "IX_Products_IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_DeudaClientes_ClienteId",
                table: "Products",
                newName: "IX_Products_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Clientes_ClienteId",
                table: "Products",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Clientes_IdCliente",
                table: "Products",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
