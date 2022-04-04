using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEducationUow.Data.Migrations
{
    public partial class CourseCOntroolerIsReady : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseAuthor",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseForId",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseImageUrl",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseType",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StarCount",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseAuthor",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDescription",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseForId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseImageUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseType",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Star",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StarCount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Courses");
        }
    }
}
