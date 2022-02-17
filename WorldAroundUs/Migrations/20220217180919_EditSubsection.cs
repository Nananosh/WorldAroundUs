using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldAroundUs.Migrations
{
    public partial class EditSubsection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Subsections");

            migrationBuilder.DropColumn(
                name: "Continent",
                table: "Subsections");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Subsections");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Subsections",
                newName: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Subsections",
                newName: "Weight");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Subsections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Continent",
                table: "Subsections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Subsections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
