using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProject.Domain.Migrations
{
    public partial class update_questiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "minhtien2",
                table: "questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_questions_UserId",
                schema: "minhtien2",
                table: "questions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_Users_UserId",
                schema: "minhtien2",
                table: "questions",
                column: "UserId",
                principalSchema: "minhtien2",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_Users_UserId",
                schema: "minhtien2",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_UserId",
                schema: "minhtien2",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "minhtien2",
                table: "questions");
        }
    }
}
