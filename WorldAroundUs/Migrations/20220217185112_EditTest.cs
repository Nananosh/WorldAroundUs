using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldAroundUs.Migrations
{
    public partial class EditTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ThemeId",
                table: "Tests",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Themes_ThemeId",
                table: "Tests",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Themes_ThemeId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_ThemeId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Tests");
        }
    }
}
