using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldAroundUs.Migrations
{
    public partial class EditTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseHistories_AspNetUsers_UserId1",
                table: "ResponseHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_AspNetUsers_UserId1",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_UserId1",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_ResponseHistories_UserId1",
                table: "ResponseHistories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ResponseHistories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestResults",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ResponseHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_UserId",
                table: "TestResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseHistories_UserId",
                table: "ResponseHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseHistories_AspNetUsers_UserId",
                table: "ResponseHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_AspNetUsers_UserId",
                table: "TestResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseHistories_AspNetUsers_UserId",
                table: "ResponseHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_AspNetUsers_UserId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_UserId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_ResponseHistories_UserId",
                table: "ResponseHistories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TestResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ResponseHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ResponseHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_UserId1",
                table: "TestResults",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseHistories_UserId1",
                table: "ResponseHistories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseHistories_AspNetUsers_UserId1",
                table: "ResponseHistories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_AspNetUsers_UserId1",
                table: "TestResults",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
