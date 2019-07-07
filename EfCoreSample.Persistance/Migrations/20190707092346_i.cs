using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreSample.Persistance.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "efcoresample");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "efcoresample",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    ReportsToId = table.Column<long>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp(6) ON UPDATE current_timestamp(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_employee_ReportsToId",
                        column: x => x.ReportsToId,
                        principalSchema: "efcoresample",
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "efcoresample",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 2147483647, nullable: true),
                    Status = table.Column<int>(maxLength: 10, nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp(6) ON UPDATE current_timestamp(6)"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartment",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartment", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "efcoresample",
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                schema: "efcoresample",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "efcoresample",
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeeproject",
                schema: "efcoresample",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false),
                    ProjectId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeproject", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_employeeproject_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "efcoresample",
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeproject_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "efcoresample",
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "efcoresample",
                table: "employee",
                columns: new[] { "Id", "FirstName", "LastName", "ReportsToId" },
                values: new object[] { 1L, "Petro", "Petrenko", null });

            migrationBuilder.InsertData(
                schema: "efcoresample",
                table: "employee",
                columns: new[] { "Id", "FirstName", "LastName", "ReportsToId" },
                values: new object[] { 2L, "Olga", "Petrenko", null });

            migrationBuilder.InsertData(
                schema: "efcoresample",
                table: "address",
                columns: new[] { "Id", "City", "Country", "EmployeeId", "PhoneNumber", "Street" },
                values: new object[] { 1L, "Ternopil", "Ukraine", 1L, null, "Lvivs`ka" });

            migrationBuilder.InsertData(
                schema: "efcoresample",
                table: "address",
                columns: new[] { "Id", "City", "Country", "EmployeeId", "PhoneNumber", "Street" },
                values: new object[] { 2L, "Ternopil", "Ukraine", 2L, null, "Tarnavs`kogo" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_DepartmentId",
                table: "EmployeeDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_address_EmployeeId",
                schema: "efcoresample",
                table: "address",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_address_City_Country_Street",
                schema: "efcoresample",
                table: "address",
                columns: new[] { "City", "Country", "Street" })
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_ReportsToId",
                schema: "efcoresample",
                table: "employee",
                column: "ReportsToId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeproject_ProjectId",
                schema: "efcoresample",
                table: "employeeproject",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartment");

            migrationBuilder.DropTable(
                name: "address",
                schema: "efcoresample");

            migrationBuilder.DropTable(
                name: "employeeproject",
                schema: "efcoresample");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "efcoresample");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "efcoresample");
        }
    }
}
