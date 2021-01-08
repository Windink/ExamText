using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class CreateExamTestAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamTestAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceAnswers = table.Column<string>(nullable: true),
                    CompletionAnswers = table.Column<string>(nullable: true),
                    ShortAnswers = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ExamTestPaperId = table.Column<int>(nullable: false),
                    branch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTestAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTestAnswers_ExamTestPapers_ExamTestPaperId",
                        column: x => x.ExamTestPaperId,
                        principalTable: "ExamTestPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamTestAnswers_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamTestAnswers_ExamTestPaperId",
                table: "ExamTestAnswers",
                column: "ExamTestPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTestAnswers_UserId",
                table: "ExamTestAnswers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamTestAnswers");
        }
    }
}
