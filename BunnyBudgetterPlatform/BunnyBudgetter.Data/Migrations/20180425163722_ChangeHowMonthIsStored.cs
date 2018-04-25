using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class ChangeHowMonthIsStored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthName",
                table: "MonthPayments");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "MonthPayments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "MonthPayments");

            migrationBuilder.AddColumn<string>(
                name: "MonthName",
                table: "MonthPayments",
                nullable: true);
        }
    }
}
