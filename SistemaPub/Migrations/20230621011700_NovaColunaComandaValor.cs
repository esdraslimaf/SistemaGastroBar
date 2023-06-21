using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPub.Migrations
{
    /// <inheritdoc />
    public partial class NovaColunaComandaValor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorComanda",
                table: "Comandas",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorComanda",
                table: "Comandas");
        }
    }
}
