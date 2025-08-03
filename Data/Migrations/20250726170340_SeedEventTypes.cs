using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedEventTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Concert" },
                    { 2, "Conference" },
                    { 3, "Workshop" },
                    { 4, "Tech Talk" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: 4);
        }
    }
}
