using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class identityInserts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlannedPayments_AccountId",
                table: "PlannedPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_AccountId",
                table: "PaymentTypes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthPayments_AccountId",
                table: "MonthPayments",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthPayments_Accounts_AccountId",
                table: "MonthPayments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Accounts_AccountId",
                table: "PaymentTypes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedPayments_Accounts_AccountId",
                table: "PlannedPayments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthPayments_Accounts_AccountId",
                table: "MonthPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Accounts_AccountId",
                table: "PaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedPayments_Accounts_AccountId",
                table: "PlannedPayments");

            migrationBuilder.DropIndex(
                name: "IX_PlannedPayments_AccountId",
                table: "PlannedPayments");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypes_AccountId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_MonthPayments_AccountId",
                table: "MonthPayments");
        }
    }
}
