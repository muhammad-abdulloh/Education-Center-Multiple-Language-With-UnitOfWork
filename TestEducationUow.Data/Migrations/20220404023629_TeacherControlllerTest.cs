using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEducationUow.Data.Migrations
{
    public partial class TeacherControlllerTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Teachers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
