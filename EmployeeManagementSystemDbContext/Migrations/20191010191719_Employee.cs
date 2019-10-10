using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystemDbContext.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbEmployees",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EManagerId = table.Column<int>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    EmpName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    WageRate = table.Column<decimal>(nullable: false),
                    Contact = table.Column<int>(maxLength: 50, nullable: false),
                    Department = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEmployees", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "DbTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TypeOfTransaction = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_DbTransactions_DbEmployees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "DbEmployees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbTransactions_EmpId",
                table: "DbTransactions",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbTransactions");

            migrationBuilder.DropTable(
                name: "DbEmployees");
        }
    }
}
