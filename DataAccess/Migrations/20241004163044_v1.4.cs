using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameLibrary_GameLibraryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryGames_GameLibrary_GameLibraryId",
                table: "LibraryGames");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameLibraryId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameLibrary",
                table: "GameLibrary");

            migrationBuilder.DropColumn(
                name: "GameLibraryId",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "GameLibrary",
                newName: "gameLibraries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gameLibraries",
                table: "gameLibraries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameGameLibrary",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    LibrariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameLibrary", x => new { x.GamesId, x.LibrariesId });
                    table.ForeignKey(
                        name: "FK_GameGameLibrary_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameLibrary_gameLibraries_LibrariesId",
                        column: x => x.LibrariesId,
                        principalTable: "gameLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameLibrary_LibrariesId",
                table: "GameGameLibrary",
                column: "LibrariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryGames_gameLibraries_GameLibraryId",
                table: "LibraryGames",
                column: "GameLibraryId",
                principalTable: "gameLibraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryGames_gameLibraries_GameLibraryId",
                table: "LibraryGames");

            migrationBuilder.DropTable(
                name: "GameGameLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gameLibraries",
                table: "gameLibraries");

            migrationBuilder.RenameTable(
                name: "gameLibraries",
                newName: "GameLibrary");

            migrationBuilder.AddColumn<int>(
                name: "GameLibraryId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameLibrary",
                table: "GameLibrary",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameLibraryId",
                table: "Games",
                column: "GameLibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameLibrary_GameLibraryId",
                table: "Games",
                column: "GameLibraryId",
                principalTable: "GameLibrary",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryGames_GameLibrary_GameLibraryId",
                table: "LibraryGames",
                column: "GameLibraryId",
                principalTable: "GameLibrary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
