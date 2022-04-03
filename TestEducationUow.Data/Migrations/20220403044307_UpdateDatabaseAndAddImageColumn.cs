using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEducationUow.Data.Migrations
{
    public partial class UpdateDatabaseAndAddImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Students",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Students");
        }
    }
}
