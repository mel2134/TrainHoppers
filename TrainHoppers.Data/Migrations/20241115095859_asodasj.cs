using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainHoppers.Data.Migrations
{
    /// <inheritdoc />
    public partial class asodasj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Powerups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PowerUpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalUses = table.Column<int>(type: "int", nullable: false),
                    UsedTime = table.Column<int>(type: "int", nullable: false),
                    PowerupType = table.Column<int>(type: "int", nullable: false)
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
                name: "Powerups");
        }
    }
}
