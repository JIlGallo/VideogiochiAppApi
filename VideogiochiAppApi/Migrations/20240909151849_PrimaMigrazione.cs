using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class PrimaMigrazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paese",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paese", x => x.Pk_Id);
                });

            migrationBuilder.CreateTable(
                name: "Videogioco",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDiRilascio = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogioco", x => x.Pk_Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Età = table.Column<int>(type: "int", nullable: false),
                    IdPaese = table.Column<int>(type: "int", nullable: true),
                    PaeseIdPaese = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Pk_Id);
                    table.ForeignKey(
                        name: "FK_Proprietario_Paese_PaeseIdPaese",
                        column: x => x.PaeseIdPaese,
                        principalTable: "Paese",
                        principalColumn: "Pk_Id");
                });

            migrationBuilder.CreateTable(
                name: "VideogiocoProprietario",
                columns: table => new
                {
                    IdVideogiocoProprietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVideogioco = table.Column<int>(type: "int", nullable: true),
                    VideogiocoIdVideogioco = table.Column<int>(type: "int", nullable: true),
                    IdProprietario = table.Column<int>(type: "int", nullable: true),
                    ProprietarioIdProprietario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogiocoProprietario", x => x.IdVideogiocoProprietario);
                    table.ForeignKey(
                        name: "FK_VideogiocoProprietario_Proprietario_ProprietarioIdProprietario",
                        column: x => x.ProprietarioIdProprietario,
                        principalTable: "Proprietario",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_VideogiocoProprietario_Videogioco_VideogiocoIdVideogioco",
                        column: x => x.VideogiocoIdVideogioco,
                        principalTable: "Videogioco",
                        principalColumn: "Pk_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_PaeseIdPaese",
                table: "Proprietario",
                column: "PaeseIdPaese");

            migrationBuilder.CreateIndex(
                name: "IX_VideogiocoProprietario_ProprietarioIdProprietario",
                table: "VideogiocoProprietario",
                column: "ProprietarioIdProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_VideogiocoProprietario_VideogiocoIdVideogioco",
                table: "VideogiocoProprietario",
                column: "VideogiocoIdVideogioco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideogiocoProprietario");

            migrationBuilder.DropTable(
                name: "Proprietario");

            migrationBuilder.DropTable(
                name: "Videogioco");

            migrationBuilder.DropTable(
                name: "Paese");
        }
    }
}
