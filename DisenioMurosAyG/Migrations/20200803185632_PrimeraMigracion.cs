using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisenioMurosAyG.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicaciones",
                columns: table => new
                {
                    AplicacionId = table.Column<string>(maxLength: 50, nullable: false),
                    AplicacionName = table.Column<string>(maxLength: 100, nullable: true),
                    Version = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicaciones", x => x.AplicacionId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioName = table.Column<string>(maxLength: 100, nullable: true),
                    UsuarioMail = table.Column<string>(maxLength: 100, nullable: false),
                    UsuarioTel = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 10, nullable: false),
                    Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    OperationId = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<string>(nullable: true),
                    AplicacionId = table.Column<string>(nullable: true),
                    InicioOperacion = table.Column<DateTime>(nullable: false),
                    FinOperacion = table.Column<DateTime>(nullable: false),
                    IpV4 = table.Column<string>(nullable: true),
                    IpV6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operaciones_Aplicaciones_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "Aplicaciones",
                        principalColumn: "AplicacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operaciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Aplicaciones",
                columns: new[] { "AplicacionId", "AplicacionName", "Version" },
                values: new object[] { "109958ab-e6fa-4a76-b531-e1b3f5c47bcb", "Diseño de muros AyG", "1.00" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Password", "Rol", "UsuarioMail", "UsuarioName", "UsuarioTel" },
                values: new object[] { "699960b2-760f-49fe-bc24-038c142efbfe", "Bucefalo_1205", 0, "santivasquez1@gmail.com", "Santiago Vasquez Gomez", null });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Password", "Rol", "UsuarioMail", "UsuarioName", "UsuarioTel" },
                values: new object[] { "7c245515-c73b-4eaf-960e-8edfb3b3daa4", "12345", 1, "anabadillo@agingenieria.com.co", "Ana Badillo", null });

            migrationBuilder.InsertData(
                table: "Operaciones",
                columns: new[] { "OperationId", "AplicacionId", "FinOperacion", "InicioOperacion", "IpV4", "IpV6", "UsuarioId" },
                values: new object[] { "0c3abe28-6a2d-4474-a780-556c8053aba8", "109958ab-e6fa-4a76-b531-e1b3f5c47bcb", new DateTime(2020, 8, 3, 14, 56, 32, 140, DateTimeKind.Local).AddTicks(7120), new DateTime(2020, 8, 3, 13, 56, 32, 139, DateTimeKind.Local).AddTicks(7110), "172.17.98.33", "::ffff:172.17.98.33", "699960b2-760f-49fe-bc24-038c142efbfe" });

            migrationBuilder.InsertData(
                table: "Operaciones",
                columns: new[] { "OperationId", "AplicacionId", "FinOperacion", "InicioOperacion", "IpV4", "IpV6", "UsuarioId" },
                values: new object[] { "7d21cbde-acfa-4804-a810-f3ece1be9cfa", "109958ab-e6fa-4a76-b531-e1b3f5c47bcb", new DateTime(2020, 8, 3, 14, 56, 32, 140, DateTimeKind.Local).AddTicks(7120), new DateTime(2020, 8, 3, 13, 56, 32, 140, DateTimeKind.Local).AddTicks(7120), "172.17.98.33", "::ffff:172.17.98.33", "7c245515-c73b-4eaf-960e-8edfb3b3daa4" });

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_AplicacionId",
                table: "Operaciones",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_UsuarioId",
                table: "Operaciones",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Aplicaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
