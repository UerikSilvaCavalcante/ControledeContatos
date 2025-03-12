using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeContatos.Migrations
{
    /// <inheritdoc />
    public partial class updateDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataCadastro", "Senha" },
                values: new object[] { new DateTime(2025, 3, 12, 0, 19, 29, 481, DateTimeKind.Utc).AddTicks(430), "f865b53623b121fd34ee5426c792e5c33af8c227" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataCadastro", "Senha" },
                values: new object[] { new DateTime(2025, 3, 11, 23, 47, 6, 743, DateTimeKind.Utc).AddTicks(1573), "admin123" });
        }
    }
}
