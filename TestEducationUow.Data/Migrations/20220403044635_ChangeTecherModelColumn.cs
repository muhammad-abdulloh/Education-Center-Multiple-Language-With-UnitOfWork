using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEducationUow.Data.Migrations
{
    public partial class ChangeTecherModelColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "text",
                nullable: true);
        }
    }
}
