using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionnaire.Migrations
{
    public partial class nextQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextQuestionConditionId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextQuestionId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_NextQuestionConditionId",
                table: "Questions",
                column: "NextQuestionConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_NextQuestionId",
                table: "Questions",
                column: "NextQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_NextQuestionConditionId",
                table: "Questions",
                column: "NextQuestionConditionId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questions_NextQuestionId",
                table: "Questions",
                column: "NextQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_NextQuestionConditionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questions_NextQuestionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_NextQuestionConditionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_NextQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "NextQuestionConditionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "NextQuestionId",
                table: "Questions");
        }
    }
}
