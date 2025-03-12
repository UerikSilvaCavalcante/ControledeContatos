using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeContatos.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAtualizado", "DataCadastro", "Email", "Login", "Nome", "Perfil", "Senha" },
                values: new object[] { 1, null, new DateTime(2025, 3, 11, 23, 27, 27, 478, DateTimeKind.Utc).AddTicks(1129), "turistajose1@gmail.com", "admin", "Admin", 1, "admin123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
