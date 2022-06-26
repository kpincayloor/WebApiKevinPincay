using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiKevinPincay.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contrasena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposCuentas",
                columns: table => new
                {
                    tipoCuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCuentas", x => x.tipoCuentaId);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    cuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroCuenta = table.Column<int>(type: "int", nullable: false),
                    tipoCuentaId = table.Column<int>(type: "int", nullable: false),
                    saldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    clienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.cuentaId);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuentas_TiposCuentas_tipoCuentaId",
                        column: x => x.tipoCuentaId,
                        principalTable: "TiposCuentas",
                        principalColumn: "tipoCuentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    movimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    cuentaId = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.movimientoId);
                    table.ForeignKey(
                        name: "FK_Movimientos_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuentas_cuentaId",
                        column: x => x.cuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "cuentaId");
                });

            migrationBuilder.InsertData(
                table: "TiposCuentas",
                columns: new[] { "tipoCuentaId", "estado", "nombre" },
                values: new object[] { 1, true, "Ahorro" });

            migrationBuilder.InsertData(
                table: "TiposCuentas",
                columns: new[] { "tipoCuentaId", "estado", "nombre" },
                values: new object[] { 2, true, "Corriente" });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_clienteId",
                table: "Cuentas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_tipoCuentaId",
                table: "Cuentas",
                column: "tipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_clienteId",
                table: "Movimientos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_cuentaId",
                table: "Movimientos",
                column: "cuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposCuentas");
        }
    }
}
