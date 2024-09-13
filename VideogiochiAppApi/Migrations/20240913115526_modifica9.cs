using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifica9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_IdProprietario",
                table: "VideogiocoProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_IdVideogioco",
                table: "VideogiocoProprietario");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_IdProprietario",
                table: "VideogiocoProprietario",
                column: "IdProprietario",
                principalTable: "Proprietario",
                principalColumn: "Pk_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_IdVideogioco",
                table: "VideogiocoProprietario",
                column: "IdVideogioco",
                principalTable: "Videogioco",
                principalColumn: "Pk_Id",
                onDelete: ReferentialAction.Cascade);
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
    }
}
