using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenresbom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "Name" },
                values: new object[] { 4, "Bom" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
