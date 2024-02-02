using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentasAPI.Migrations
{
    public partial class mig4addedFlujoFondoYPagoProveedorEntidadesYRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Productos",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "PagoProveedors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProveedor = table.Column<int>(type: "INTEGER", nullable: false),
                    Pagos = table.Column<decimal>(type: "TEXT", nullable: false),
                    MontoFinal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoProveedors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagoProveedors_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlujoFondos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdIngresoCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPagoProveedor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProveedor = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingresos = table.Column<decimal>(type: "TEXT", nullable: false),
                    Pagos = table.Column<decimal>(type: "TEXT", nullable: false),
                    SaldoFinal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlujoFondos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlujoFondos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlujoFondos_IngresoClientes_IdIngresoCliente",
                        column: x => x.IdIngresoCliente,
                        principalTable: "IngresoClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlujoFondos_PagoProveedors_IdPagoProveedor",
                        column: x => x.IdPagoProveedor,
                        principalTable: "PagoProveedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlujoFondos_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlujoFondos_IdCliente",
                table: "FlujoFondos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoFondos_IdIngresoCliente",
                table: "FlujoFondos",
                column: "IdIngresoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoFondos_IdPagoProveedor",
                table: "FlujoFondos",
                column: "IdPagoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoFondos_IdProveedor",
                table: "FlujoFondos",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_PagoProveedors_IdProveedor",
                table: "PagoProveedors",
                column: "IdProveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlujoFondos");

            migrationBuilder.DropTable(
                name: "PagoProveedors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Productos",
                newName: "IdProducto");
        }
    }
}
