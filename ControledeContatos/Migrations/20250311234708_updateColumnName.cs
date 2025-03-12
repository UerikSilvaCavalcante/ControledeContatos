using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeContatos.Migrations
{
    /// <inheritdoc />
    public partial class updateColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Contatos",
                newName: "contatos");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_UsuarioId",
                table: "contatos",
                newName: "IX_contatos_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contatos",
                table: "contatos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 23, 47, 6, 743, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.AddForeignKey(
                name: "FK_contatos_usuarios_UsuarioId",
                table: "contatos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contatos_usuarios_UsuarioId",
                table: "contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contatos",
                table: "contatos");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "contatos",
                newName: "Contatos");

            migrationBuilder.RenameIndex(
                name: "IX_contatos_UsuarioId",
                table: "Contatos",
                newName: "IX_Contatos_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 23, 27, 27, 478, DateTimeKind.Utc).AddTicks(1129));

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
