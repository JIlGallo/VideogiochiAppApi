using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifica10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VideogiocoProprietario",
                columns: new[] { "IdVideogiocoProprietario", "IdProprietario", "IdVideogioco" },
                values: new object[,]
                {
                    { 6, 5, 3 },
                    { 7, 7, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 7);
        }
    }
}
