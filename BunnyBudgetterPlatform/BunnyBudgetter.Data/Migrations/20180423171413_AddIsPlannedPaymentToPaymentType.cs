using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class AddIsPlannedPaymentToPaymentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPlannedPayment",
                table: "PaymentTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlannedPayment",
                table: "PaymentTypes");
        }
    }
}
