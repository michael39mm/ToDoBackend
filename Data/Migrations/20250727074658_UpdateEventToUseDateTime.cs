using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventToUseDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Events",
                newName: "Datetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "Events",
                newName: "Time");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
