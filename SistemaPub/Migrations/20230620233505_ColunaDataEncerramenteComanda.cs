using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPub.Migrations
{
    /// <inheritdoc />
    public partial class ColunaDataEncerramenteComanda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Comandas",
                newName: "DataComandaAbriu");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataComandaFechada",
                table: "Comandas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataComandaFechada",
                table: "Comandas");

            migrationBuilder.RenameColumn(
                name: "DataComandaAbriu",
                table: "Comandas",
                newName: "Data");
        }
    }
}
