using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinees_AbpUsers_Id",
                table: "Examinees");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Examinees",
                newName: "ExamnesID");

            migrationBuilder.AlterColumn<int>(
                name: "ExamnesID",
                table: "Examinees",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ExamLoginNum",
                table: "Examinees",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExamLoginPassword",
                table: "Examinees",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Examinees",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamLoginNum",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "ExamLoginPassword",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Examinees");

            migrationBuilder.RenameColumn(
                name: "ExamnesID",
                table: "Examinees",
                newName: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Examinees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinees_AbpUsers_Id",
                table: "Examinees",
                column: "Id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
