using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "Sports" },
                    { 3, "Open-Wrld" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
