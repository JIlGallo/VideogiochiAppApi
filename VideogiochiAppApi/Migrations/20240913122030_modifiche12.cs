using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiche12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VideogiocoProprietario",
                columns: new[] { "IdVideogiocoProprietario", "IdProprietario", "IdVideogioco" },
                values: new object[] { 1, 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 1);
        }
    }
}
