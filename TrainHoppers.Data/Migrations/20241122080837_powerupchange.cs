using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainHoppers.Data.Migrations
{
    /// <inheritdoc />
    public partial class powerupchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsedTime",
                table: "Powerups",
                newName: "UsesLeft");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsesLeft",
                table: "Powerups",
                newName: "UsedTime");
        }
    }
}
