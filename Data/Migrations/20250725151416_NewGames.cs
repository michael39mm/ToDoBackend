using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "id", "GenreId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Street Fighter", 19.99m },
                    { 2, 2, "FIFA", 29.99m },
                    { 3, 3, "GTA", 49.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
