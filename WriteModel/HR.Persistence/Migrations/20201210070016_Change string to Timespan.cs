using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class ChangestringtoTimespan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                schema: "ShiftContext",
                table: "ShiftSegment",
                type: "Time",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                schema: "ShiftContext",
                table: "ShiftSegment",
                type: "Time",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "ExiTime",
                schema: "EmployeeContext",
                table: "IO",
                type: "VarChar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalTime",
                schema: "EmployeeContext",
                table: "IO",
                type: "VarChar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar(8)",
                oldMaxLength: 8,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                schema: "ShiftContext",
                table: "ShiftSegment",
                type: "VarChar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "Time",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                schema: "ShiftContext",
                table: "ShiftSegment",
                type: "VarChar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "Time",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "ExiTime",
                schema: "EmployeeContext",
                table: "IO",
                type: "VarChar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalTime",
                schema: "EmployeeContext",
                table: "IO",
                type: "VarChar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(8)",
                oldMaxLength: 8);
        }
    }
}
