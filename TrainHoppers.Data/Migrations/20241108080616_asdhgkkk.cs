using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainHoppers.Data.Migrations
{
    /// <inheritdoc />
    public partial class asdhgkkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SideEffects",
                table: "Abilities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SideEffects",
                table: "Abilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
