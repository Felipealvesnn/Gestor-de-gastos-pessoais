using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_de_gastos_pessoais_data.Migrations
{
    /// <inheritdoc />
    public partial class adionadoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "whatsapp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "localGastos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    Cnhpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localGastos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipoGastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoGastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalgastoId = table.Column<int>(type: "int", nullable: false),
                    TipogastoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gastos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gastos_localGastos_LocalgastoId",
                        column: x => x.LocalgastoId,
                        principalTable: "localGastos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gastos_tipoGastos_TipogastoId",
                        column: x => x.TipogastoId,
                        principalTable: "tipoGastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gastos_LocalgastoId",
                table: "gastos",
                column: "LocalgastoId");

            migrationBuilder.CreateIndex(
                name: "IX_gastos_TipogastoId",
                table: "gastos",
                column: "TipogastoId");

            migrationBuilder.CreateIndex(
                name: "IX_gastos_UserId",
                table: "gastos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gastos");

            migrationBuilder.DropTable(
                name: "localGastos");

            migrationBuilder.DropTable(
                name: "tipoGastos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "whatsapp",
                table: "AspNetUsers");
        }
    }
}
