using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmpId",
                table: "Transactions",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmpId",
                table: "Transactions",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmpId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmpId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Transactions");
        }
    }
}
