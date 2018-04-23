﻿// <auto-generated />
using BunnyBudgetterPlatform.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BunnyBudgetter.Data.Migrations
{
    [DbContext(typeof(BunnyBudgetterPlatformContext))]
    [Migration("20180423222607_RemoveAmountLeftFromPaymentType")]
    partial class RemoveAmountLeftFromPaymentType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.AccountUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("AccountUsers");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.MonthPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<bool>("IsCurrentMonth");

                    b.Property<string>("MonthName");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("MonthPayments");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<int>("DayOfMonth");

                    b.Property<string>("Description");

                    b.Property<int?>("MonthPaymentId");

                    b.Property<int?>("PaymentTypeId");

                    b.Property<int?>("PlannedPaymentId");

                    b.HasKey("Id");

                    b.HasIndex("MonthPaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<bool>("IsPlannedPayment");

                    b.Property<float>("MaxAmount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.PlannedPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<float>("Amount");

                    b.Property<int>("DayOfMonth");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("PlannedPayments");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<bool>("IsLockedOut");

                    b.Property<int>("NumberOfAttempts");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.AccountUser", b =>
                {
                    b.HasOne("BunnyBudgetter.Data.Entities.Account", "Account")
                        .WithMany("AccountUsers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BunnyBudgetter.Data.Entities.User", "User")
                        .WithMany("AccountUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.MonthPayment", b =>
                {
                    b.HasOne("BunnyBudgetter.Data.Entities.Account")
                        .WithMany("MonthPayments")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.Payment", b =>
                {
                    b.HasOne("BunnyBudgetter.Data.Entities.MonthPayment")
                        .WithMany("Payments")
                        .HasForeignKey("MonthPaymentId");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.PaymentType", b =>
                {
                    b.HasOne("BunnyBudgetter.Data.Entities.Account")
                        .WithMany("PaymentTypes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.PlannedPayment", b =>
                {
                    b.HasOne("BunnyBudgetter.Data.Entities.Account")
                        .WithMany("PlannedPayments")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
