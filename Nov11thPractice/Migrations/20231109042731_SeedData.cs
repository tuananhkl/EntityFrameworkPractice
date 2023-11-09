using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nov11thPractice.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.CheckConstraint("CK_Person_Age", "Age >= 0 AND Age <= 120");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Department", "FirstName", "LastName" },
                values: new object[] { new Guid("09e2df50-963d-47bb-b4f2-e7f15f5b1000"), 30, "HR", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Department", "FirstName", "LastName" },
                values: new object[] { new Guid("5522f805-45fc-4624-bd63-7da7a619b623"), 28, "Finance", "Jane", "Smith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
