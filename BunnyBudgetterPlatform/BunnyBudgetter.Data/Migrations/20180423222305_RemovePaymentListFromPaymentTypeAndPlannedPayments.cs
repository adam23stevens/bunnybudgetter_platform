using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class RemovePaymentListFromPaymentTypeAndPlannedPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PlannedPayments_PlannedPaymentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PlannedPaymentId",
                table: "Payments");

            migrationBuilder.AddColumn<float>(
                name: "AmountRemainingForMonth",
                table: "PaymentTypes",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountRemainingForMonth",
                table: "PaymentTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PlannedPaymentId",
                table: "Payments",
                column: "PlannedPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PlannedPayments_PlannedPaymentId",
                table: "Payments",
                column: "PlannedPaymentId",
                principalTable: "PlannedPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
