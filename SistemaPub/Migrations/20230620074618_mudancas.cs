using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPub.Migrations
{
    /// <inheritdoc />
    public partial class mudancas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Clientes_ClienteId",
                table: "Comandas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Comandas_ClienteId",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ProdutosComandas");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Comandas",
                newName: "Ativa");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Comandas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdentificaCliente",
                table: "Comandas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "IdentificaCliente",
                table: "Comandas");

            migrationBuilder.RenameColumn(
                name: "Ativa",
                table: "Comandas",
                newName: "ClienteId");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ProdutosComandas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_ClienteId",
                table: "Comandas",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Clientes_ClienteId",
                table: "Comandas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
