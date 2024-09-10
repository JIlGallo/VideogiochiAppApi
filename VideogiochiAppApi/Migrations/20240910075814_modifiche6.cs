using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiche6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pk_Id",
                table: "VideogiocoProprietario",
                newName: "IdVideogiocoProprietario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdVideogiocoProprietario",
                table: "VideogiocoProprietario",
                newName: "Pk_Id");
        }
    }
}
