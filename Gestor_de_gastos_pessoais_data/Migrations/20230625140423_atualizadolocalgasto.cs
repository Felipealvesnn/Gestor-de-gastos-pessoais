using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_de_gastos_pessoais_data.Migrations
{
    /// <inheritdoc />
    public partial class atualizadolocalgasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "gastos",
                newName: "DataGasto");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "localGastos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "localGastos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PontoReferencia",
                table: "localGastos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastrado",
                table: "gastos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "localGastos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "localGastos");

            migrationBuilder.DropColumn(
                name: "PontoReferencia",
                table: "localGastos");

            migrationBuilder.DropColumn(
                name: "DataCadastrado",
                table: "gastos");

            migrationBuilder.RenameColumn(
                name: "DataGasto",
                table: "gastos",
                newName: "Data");
        }
    }
}
