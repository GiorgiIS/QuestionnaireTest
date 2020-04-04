using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionnaire.Migrations
{
    public partial class someChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainQuestion",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Score", "Text" },
                values: new object[,]
                {
                    { 1, 2, "Yes" },
                    { 2, 1, "Sometimes" },
                    { 3, 0, "No" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "IsMainQuestion", "NextQuestionConditionId", "NextQuestionId", "Text" },
                values: new object[,]
                {
                    { 2, false, null, null, "If you see this question you have answered fist question yes" },
                    { 3, true, null, null, "This is just 3th question" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "IsMainQuestion", "NextQuestionConditionId", "NextQuestionId", "Text" },
                values: new object[] { 1, true, 1, 2, "If you answer this question yes, you will get question 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsMainQuestion",
                table: "Questions");
        }
    }
}
