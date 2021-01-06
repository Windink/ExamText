using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class sdada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TureAnswerIndex",
                table: "ExamChoiceQuestion");

            migrationBuilder.AddColumn<string>(
                name: "TrueAnswerIndex",
                table: "ExamChoiceQuestion",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrueAnswerIndex",
                table: "ExamChoiceQuestion");

            migrationBuilder.AddColumn<string>(
                name: "TureAnswerIndex",
                table: "ExamChoiceQuestion",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
