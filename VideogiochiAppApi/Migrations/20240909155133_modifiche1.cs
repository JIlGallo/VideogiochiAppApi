using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiche1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proprietario_Paese_PaeseIdPaese",
                table: "Proprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_ProprietarioIdProprietario",
                table: "VideogiocoProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_VideogiocoIdVideogioco",
                table: "VideogiocoProprietario");

            migrationBuilder.DropIndex(
                name: "IX_VideogiocoProprietario_ProprietarioIdProprietario",
                table: "VideogiocoProprietario");

            migrationBuilder.DropIndex(
                name: "IX_VideogiocoProprietario_VideogiocoIdVideogioco",
                table: "VideogiocoProprietario");

            migrationBuilder.DropIndex(
                name: "IX_Proprietario_PaeseIdPaese",
                table: "Proprietario");

            migrationBuilder.DropColumn(
                name: "ProprietarioIdProprietario",
                table: "VideogiocoProprietario");

            migrationBuilder.DropColumn(
                name: "VideogiocoIdVideogioco",
                table: "VideogiocoProprietario");

            migrationBuilder.DropColumn(
                name: "PaeseIdPaese",
                table: "Proprietario");

            migrationBuilder.RenameColumn(
                name: "IdVideogioco",
                table: "VideogiocoProprietario",
                newName: "Fk_Videogioco_Id");

            migrationBuilder.RenameColumn(
                name: "IdProprietario",
                table: "VideogiocoProprietario",
                newName: "Fk_Proprietario_Id");

            migrationBuilder.RenameColumn(
                name: "IdPaese",
                table: "Proprietario",
                newName: "Fk_Paese_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VideogiocoProprietario_Fk_Proprietario_Id",
                table: "VideogiocoProprietario",
                column: "Fk_Proprietario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VideogiocoProprietario_Fk_Videogioco_Id",
                table: "VideogiocoProprietario",
                column: "Fk_Videogioco_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_Fk_Paese_Id",
                table: "Proprietario",
                column: "Fk_Paese_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietario_Paese_Fk_Paese_Id",
                table: "Proprietario",
                column: "Fk_Paese_Id",
                principalTable: "Paese",
                principalColumn: "Pk_Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proprietario_Paese_Fk_Paese_Id",
                table: "Proprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_Fk_Proprietario_Id",
                table: "VideogiocoProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_Fk_Videogioco_Id",
                table: "VideogiocoProprietario");

            migrationBuilder.DropIndex(
                name: "IX_VideogiocoProprietario_Fk_Proprietario_Id",
                table: "VideogiocoProprietario");

            migrationBuilder.DropIndex(
                name: "IX_VideogiocoProprietario_Fk_Videogioco_Id",
                table: "VideogiocoProprietario");

            migrationBuilder.DropIndex(
                name: "IX_Proprietario_Fk_Paese_Id",
                table: "Proprietario");

            migrationBuilder.RenameColumn(
                name: "Fk_Videogioco_Id",
                table: "VideogiocoProprietario",
                newName: "IdVideogioco");

            migrationBuilder.RenameColumn(
                name: "Fk_Proprietario_Id",
                table: "VideogiocoProprietario",
                newName: "IdProprietario");

            migrationBuilder.RenameColumn(
                name: "Fk_Paese_Id",
                table: "Proprietario",
                newName: "IdPaese");

            migrationBuilder.AddColumn<int>(
                name: "ProprietarioIdProprietario",
                table: "VideogiocoProprietario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideogiocoIdVideogioco",
                table: "VideogiocoProprietario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaeseIdPaese",
                table: "Proprietario",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 1,
                column: "PaeseIdPaese",
                value: null);

            migrationBuilder.UpdateData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 2,
                column: "PaeseIdPaese",
                value: null);

            migrationBuilder.UpdateData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 3,
                column: "PaeseIdPaese",
                value: null);

            migrationBuilder.UpdateData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 1,
                columns: new[] { "ProprietarioIdProprietario", "VideogiocoIdVideogioco" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 2,
                columns: new[] { "ProprietarioIdProprietario", "VideogiocoIdVideogioco" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 3,
                columns: new[] { "ProprietarioIdProprietario", "VideogiocoIdVideogioco" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_VideogiocoProprietario_ProprietarioIdProprietario",
                table: "VideogiocoProprietario",
                column: "ProprietarioIdProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_VideogiocoProprietario_VideogiocoIdVideogioco",
                table: "VideogiocoProprietario",
                column: "VideogiocoIdVideogioco");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_PaeseIdPaese",
                table: "Proprietario",
                column: "PaeseIdPaese");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietario_Paese_PaeseIdPaese",
                table: "Proprietario",
                column: "PaeseIdPaese",
                principalTable: "Paese",
                principalColumn: "Pk_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Proprietario_ProprietarioIdProprietario",
                table: "VideogiocoProprietario",
                column: "ProprietarioIdProprietario",
                principalTable: "Proprietario",
                principalColumn: "Pk_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogiocoProprietario_Videogioco_VideogiocoIdVideogioco",
                table: "VideogiocoProprietario",
                column: "VideogiocoIdVideogioco",
                principalTable: "Videogioco",
                principalColumn: "Pk_Id");
        }
    }
}
