using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiche4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_Fk_Proprietario_Id",
                table: "VideogiocoProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_Fk_Videogioco_Id",
                table: "VideogiocoProprietario");

            migrationBuilder.RenameColumn(
                name: "Fk_Videogioco_Id",
                table: "VideogiocoProprietario",
                newName: "IdVideogioco");

            migrationBuilder.RenameColumn(
                name: "Fk_Proprietario_Id",
                table: "VideogiocoProprietario",
                newName: "IdProprietario");

            migrationBuilder.RenameColumn(
                name: "IdVideogiocoProprietario",
                table: "VideogiocoProprietario",
                newName: "Pk_Id");

            migrationBuilder.RenameIndex(
                name: "IX_VideogiocoProprietario_Fk_Videogioco_Id",
                table: "VideogiocoProprietario",
                newName: "IX_VideogiocoProprietario_IdVideogioco");

            migrationBuilder.RenameIndex(
                name: "IX_VideogiocoProprietario_Fk_Proprietario_Id",
                table: "VideogiocoProprietario",
                newName: "IX_VideogiocoProprietario_IdProprietario");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_IdProprietario",
                table: "VideogiocoProprietario",
                column: "IdProprietario",
                principalTable: "Proprietario",
                principalColumn: "Pk_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_IdVideogioco",
                table: "VideogiocoProprietario",
                column: "IdVideogioco",
                principalTable: "Videogioco",
                principalColumn: "Pk_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_IdProprietario",
                table: "VideogiocoProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_IdVideogioco",
                table: "VideogiocoProprietario");

            migrationBuilder.RenameColumn(
                name: "IdVideogioco",
                table: "VideogiocoProprietario",
                newName: "Fk_Videogioco_Id");

            migrationBuilder.RenameColumn(
                name: "IdProprietario",
                table: "VideogiocoProprietario",
                newName: "Fk_Proprietario_Id");

            migrationBuilder.RenameColumn(
                name: "Pk_Id",
                table: "VideogiocoProprietario",
                newName: "IdVideogiocoProprietario");

            migrationBuilder.RenameIndex(
                name: "IX_VideogiocoProprietario_IdVideogioco",
                table: "VideogiocoProprietario",
                newName: "IX_VideogiocoProprietario_Fk_Videogioco_Id");

            migrationBuilder.RenameIndex(
                name: "IX_VideogiocoProprietario_IdProprietario",
                table: "VideogiocoProprietario",
                newName: "IX_VideogiocoProprietario_Fk_Proprietario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_Fk_Proprietario_Id",
                table: "VideogiocoProprietario",
                column: "Fk_Proprietario_Id",
                principalTable: "Proprietario",
                principalColumn: "Pk_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_Fk_Videogioco_Id",
                table: "VideogiocoProprietario",
                column: "Fk_Videogioco_Id",
                principalTable: "Videogioco",
                principalColumn: "Pk_Id");
        }
    }
}
