using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class AddIndexFieldToShiftSegmntTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EmployeeContext");

            migrationBuilder.EnsureSchema(
                name: "ShiftContext");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PersonalCode = table.Column<long>(type: "BigInt", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "ShiftContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ShiftTitle = table.Column<string>(type: "NVarChar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignShift",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Index = table.Column<int>(type: "Int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AssignShifts",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shift_AssignShifts",
                        column: x => x.ShiftId,
                        principalSchema: "ShiftContext",
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Contracts",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IO",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    ArrivalTime = table.Column<string>(type: "VarChar(8)", maxLength: 8, nullable: true),
                    ExiTime = table.Column<string>(type: "VarChar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_IOs",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftSegment",
                schema: "ShiftContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Index = table.Column<int>(type: "Int", nullable: false),
                    StartTime = table.Column<string>(type: "VarChar(8)", maxLength: 8, nullable: false),
                    EndTime = table.Column<string>(type: "VarChar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_ShiftPeriods",
                        column: x => x.ShiftId,
                        principalSchema: "ShiftContext",
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignShift_EmployeeId",
                schema: "EmployeeContext",
                table: "AssignShift",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignShift_ShiftId",
                schema: "EmployeeContext",
                table: "AssignShift",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EmployeeId",
                schema: "EmployeeContext",
                table: "Contract",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_IO_EmployeeId",
                schema: "EmployeeContext",
                table: "IO",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftSegment_ShiftId",
                schema: "ShiftContext",
                table: "ShiftSegment",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignShift",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "Contract",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "IO",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "ShiftSegment",
                schema: "ShiftContext");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "ShiftContext");
        }
    }
}
