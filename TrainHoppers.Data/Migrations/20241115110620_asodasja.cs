using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainHoppers.Data.Migrations
{
    /// <inheritdoc />
    public partial class asodasja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Powerups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Powerups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PowerupID",
                table: "FilesToDatabase",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Powerups");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Powerups");

            migrationBuilder.DropColumn(
                name: "PowerupID",
                table: "FilesToDatabase");
        }
    }
}
