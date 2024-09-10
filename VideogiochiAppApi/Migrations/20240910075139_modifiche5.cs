using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiche5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Proprietario",
                columns: new[] { "Pk_Id", "Età", "IdPaese", "Nome" },
                values: new object[] { 4, 45, 2, "Drake" });

            migrationBuilder.InsertData(
                table: "Videogioco",
                columns: new[] { "Pk_Id", "DataDiRilascio", "Nome" },
                values: new object[] { 4, new DateOnly(2016, 5, 3), "Uncharted 4: A thief's end" });

            migrationBuilder.InsertData(
                table: "VideogiocoProprietario",
                columns: new[] { "Pk_Id", "IdProprietario", "IdVideogioco" },
                values: new object[,]
                {
                    { 4, 4, 1 },
                    { 5, 1, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "Pk_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "Pk_Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Videogioco",
                keyColumn: "Pk_Id",
                keyValue: 4);
        }
    }
}
