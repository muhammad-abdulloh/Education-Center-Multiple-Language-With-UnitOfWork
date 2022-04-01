using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEducationUow.Data.Migrations
{
    public partial class UptemizeDatabseDepartamentBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary");

            migrationBuilder.RenameTable(
                name: "EmployeeSalary",
                newName: "EmployeeSalaries");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaries",
                newName: "EmployeeSalary");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalary",
                newName: "IX_EmployeeSalary_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
