using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideogiochiAppApi.Migrations
{
    /// <inheritdoc />
    public partial class nuova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Paese",
                columns: new[] { "Pk_Id", "Name" },
                values: new object[,]
                {
                    { 1, "Italia" },
                    { 2, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Proprietario",
                columns: new[] { "Pk_Id", "Età", "IdPaese", "Nome", "PaeseIdPaese" },
                values: new object[,]
                {
                    { 1, 35, 1, "Mario", null },
                    { 2, 30, 1, "Luigi", null },
                    { 3, 28, 2, "John", null }
                });

            migrationBuilder.InsertData(
                table: "Videogioco",
                columns: new[] { "Pk_Id", "DataDiRilascio", "Nome" },
                values: new object[,]
                {
                    { 1, new DateOnly(1985, 9, 13), "Super Mario" },
                    { 2, new DateOnly(1986, 2, 21), "The Legend of Zelda" },
                    { 3, new DateOnly(1981, 7, 9), "Donkey Kong" }
                });

            migrationBuilder.InsertData(
                table: "VideogiocoProprietario",
                columns: new[] { "IdVideogiocoProprietario", "IdProprietario", "IdVideogioco", "ProprietarioIdProprietario", "VideogiocoIdVideogioco" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null },
                    { 2, 2, 2, null, null },
                    { 3, 3, 3, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paese",
                keyColumn: "Pk_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paese",
                keyColumn: "Pk_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proprietario",
                keyColumn: "Pk_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Videogioco",
                keyColumn: "Pk_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Videogioco",
                keyColumn: "Pk_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Videogioco",
                keyColumn: "Pk_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideogiocoProprietario",
                keyColumn: "IdVideogiocoProprietario",
                keyValue: 3);
        }
    }
}
