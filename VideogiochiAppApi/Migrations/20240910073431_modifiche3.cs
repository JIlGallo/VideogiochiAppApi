using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiche3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proprietario_Paese_Fk_Paese_Id",
                table: "Proprietario");

            migrationBuilder.RenameColumn(
                name: "Fk_Paese_Id",
                table: "Proprietario",
                newName: "IdPaese");

            migrationBuilder.RenameIndex(
                name: "IX_Proprietario_Fk_Paese_Id",
                table: "Proprietario",
                newName: "IX_Proprietario_IdPaese");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietario_Paese_IdPaese",
                table: "Proprietario",
                column: "IdPaese",
                principalTable: "Paese",
                principalColumn: "Pk_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proprietario_Paese_IdPaese",
                table: "Proprietario");

            migrationBuilder.RenameColumn(
                name: "IdPaese",
                table: "Proprietario",
                newName: "Fk_Paese_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Proprietario_IdPaese",
                table: "Proprietario",
                newName: "IX_Proprietario_Fk_Paese_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietario_Paese_Fk_Paese_Id",
                table: "Proprietario",
                column: "Fk_Paese_Id",
                principalTable: "Paese",
                principalColumn: "Pk_Id");
        }
    }
}
