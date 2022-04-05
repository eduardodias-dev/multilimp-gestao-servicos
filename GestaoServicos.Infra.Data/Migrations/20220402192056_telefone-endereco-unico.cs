using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoServicos.Infra.Data.Migrations
{
    public partial class telefoneenderecounico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");
        }
    }
}
