using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class RemoveAmountLeftFromPaymentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountRemainingForMonth",
                table: "PaymentTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AmountRemainingForMonth",
                table: "PaymentTypes",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
