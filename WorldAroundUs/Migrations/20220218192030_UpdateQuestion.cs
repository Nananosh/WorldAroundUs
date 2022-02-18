using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldAroundUs.Migrations
{
    public partial class UpdateQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerOptionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "AnswerOptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerOptionId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "AnswerOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
