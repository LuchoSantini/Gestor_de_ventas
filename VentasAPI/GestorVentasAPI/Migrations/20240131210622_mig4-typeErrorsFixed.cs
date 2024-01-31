using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig4typeErrorsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Productos",
                newName: "Descripcion");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Productos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Productos",
                newName: "Description");
        }
    }
}
