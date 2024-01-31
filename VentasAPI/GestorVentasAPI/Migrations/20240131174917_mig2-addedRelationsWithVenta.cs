using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig2addedRelationsWithVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDeVentas_Ventas_VentaId",
                table: "OrdenDeVentas");

            migrationBuilder.DropIndex(
                name: "IX_OrdenDeVentas_VentaId",
                table: "OrdenDeVentas");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "OrdenDeVentas");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVentas_IdVenta",
                table: "OrdenDeVentas",
                column: "IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDeVentas_Ventas_IdVenta",
                table: "OrdenDeVentas",
                column: "IdVenta",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDeVentas_Ventas_IdVenta",
                table: "OrdenDeVentas");

            migrationBuilder.DropIndex(
                name: "IX_OrdenDeVentas_IdVenta",
                table: "OrdenDeVentas");

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "OrdenDeVentas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVentas_VentaId",
                table: "OrdenDeVentas",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDeVentas_Ventas_VentaId",
                table: "OrdenDeVentas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }
    }
}
