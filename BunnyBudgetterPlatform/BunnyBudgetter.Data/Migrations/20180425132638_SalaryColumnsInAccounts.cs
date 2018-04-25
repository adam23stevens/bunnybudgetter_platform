using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class SalaryColumnsInAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "Payments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateSalaryPaid",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "MonthlyNetSalaryAmount",
                table: "Accounts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextDateSalaryPaid",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SalaryDayPaid",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaryScheduleType",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LastDateSalaryPaid",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "MonthlyNetSalaryAmount",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "NextDateSalaryPaid",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SalaryDayPaid",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SalaryScheduleType",
                table: "Accounts");
        }
    }
}
