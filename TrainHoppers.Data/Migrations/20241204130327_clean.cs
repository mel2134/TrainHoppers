using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainHoppers.Data.Migrations
{
    /// <inheritdoc />
    public partial class clean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbilityRechargeTime = table.Column<int>(type: "int", nullable: false),
                    AbilityUseTime = table.Column<int>(type: "int", nullable: false),
                    AbilityStatus = table.Column<int>(type: "int", nullable: false),
                    AbilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityLevel = table.Column<int>(type: "int", nullable: false),
                    AbilityXP = table.Column<int>(type: "int", nullable: false),
                    AbilityXPUntilNextLevel = table.Column<int>(type: "int", nullable: false),
                    AbilityType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AbilityID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PowerupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Powerups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PowerUpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalUses = table.Column<int>(type: "int", nullable: false),
                    UsesLeft = table.Column<int>(type: "int", nullable: false),
                    PowerupType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powerups", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropTable(
                name: "Powerups");
        }
    }
}
