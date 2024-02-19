using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingresos",
                table: "FlujoFondos",
                newName: "MontoFinalPagos");

            migrationBuilder.AddColumn<decimal>(
                name: "Ingresoos",
                table: "FlujoFondos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoFinalIngresos",
                table: "FlujoFondos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingresoos",
                table: "FlujoFondos");

            migrationBuilder.DropColumn(
                name: "MontoFinalIngresos",
                table: "FlujoFondos");

            migrationBuilder.RenameColumn(
                name: "MontoFinalPagos",
                table: "FlujoFondos",
                newName: "Ingresos");
        }
    }
}
