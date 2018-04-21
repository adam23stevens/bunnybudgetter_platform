﻿// <auto-generated />
using BunnyBudgetterPlatform.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace BunnyBudgetter.Data.Migrations
{
    [DbContext(typeof(BunnyBudgetterPlatformContext))]
    [Migration("20180421195517_EntitiesAdded")]
    partial class EntitiesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.MonthPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCurrentMonth");

                    b.Property<string>("MonthName");

                    b.HasKey("Id");

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

                    b.HasKey("Id");

                    b.HasIndex("MonthPaymentId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("MaxAmount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.PlannedPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayOfMonth");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

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

                    b.ToTable("User");
                });

            modelBuilder.Entity("BunnyBudgetter.Data.Entities.Payment", b =>
                {
                    b.HasOne("BunnyBudgetter.Data.Entities.MonthPayment")
                        .WithMany("Payments")
                        .HasForeignKey("MonthPaymentId");

                    b.HasOne("BunnyBudgetter.Data.Entities.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
