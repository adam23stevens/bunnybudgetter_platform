using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BunnyBudgetter.Data.Migrations
{
    public partial class IdsToJoinPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PlannedPayments_PlannedPaymentId",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedPaymentId",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PlannedPayments_PlannedPaymentId",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedPaymentId",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PlannedPayments_PlannedPaymentId",
                table: "Payments",
                column: "PlannedPaymentId",
                principalTable: "PlannedPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
