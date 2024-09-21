﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using congestion_tax_calculator.Data;

#nullable disable

namespace congestion_tax_calculator.Migrations
{
    [DbContext(typeof(congestion_tax_calculatorContext))]
    [Migration("20240921095835_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("congestion_tax_calculator.Models.Holidays.DaysOfMonth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("MonthId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonthId");

                    b.ToTable("DaysOfMonth");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.Holidays.Month", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Month");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxExemptVehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsExemptVehicle")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxExemptVehicles");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxRecords.TaxRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarTypeId");

                    b.ToTable("TaxRecord");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxRecords.TaxRecordTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaxRecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxRecordId");

                    b.ToTable("TaxRecordTimes");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("FromTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("ToTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("TaxRule");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.WeekendDays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeekendDays");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.Holidays.DaysOfMonth", b =>
                {
                    b.HasOne("congestion_tax_calculator.Models.Holidays.Month", "Month")
                        .WithMany("DaysOfMonth")
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Month");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxRecords.TaxRecord", b =>
                {
                    b.HasOne("congestion_tax_calculator.Models.TaxExemptVehicles", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarType");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxRecords.TaxRecordTime", b =>
                {
                    b.HasOne("congestion_tax_calculator.Models.TaxRecords.TaxRecord", "TaxRecord")
                        .WithMany("TaxRecordTimes")
                        .HasForeignKey("TaxRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxRecord");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.Holidays.Month", b =>
                {
                    b.Navigation("DaysOfMonth");
                });

            modelBuilder.Entity("congestion_tax_calculator.Models.TaxRecords.TaxRecord", b =>
                {
                    b.Navigation("TaxRecordTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
