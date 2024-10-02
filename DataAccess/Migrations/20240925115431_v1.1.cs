using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_GameLibrary_GamesId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GamesId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GamesId",
                table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GamesId",
                table: "Players",
                column: "GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_GameLibrary_GamesId",
                table: "Players",
                column: "GamesId",
                principalTable: "GameLibrary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
