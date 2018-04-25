using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class SetAccessCodeStringType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccessCode",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccessCode",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
