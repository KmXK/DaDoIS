﻿// <auto-generated />
using System;
using DaDoIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DaDoIS.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240204174242_DepositModelFix")]
    partial class DepositModelFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DaDoIS.Data.Entities.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("Debit")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Citizenship");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CitizenshipId")
                        .HasColumnType("int");

                    b.Property<int>("DisabilityGroup")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HomePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("IsLiableForMilitaryService")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRetired")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LivingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LivingCityId")
                        .HasColumnType("int");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("PassportIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportIssuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistrationCityId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("WorkPlace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CitizenshipId");

                    b.HasIndex("LivingCityId");

                    b.HasIndex("RegistrationCityId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<bool>("IsRevocable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.DepositContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DepositId");

                    b.ToTable("DepositContracts");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.TransitLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.HasIndex("TargetId");

                    b.ToTable("TransitLogs");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.BankAccount", b =>
                {
                    b.HasOne("DaDoIS.Data.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.Client", b =>
                {
                    b.HasOne("DaDoIS.Data.Entities.Citizenship", "Citizenship")
                        .WithMany()
                        .HasForeignKey("CitizenshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaDoIS.Data.Entities.City", "LivingCity")
                        .WithMany()
                        .HasForeignKey("LivingCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DaDoIS.Data.Entities.City", "RegistrationCity")
                        .WithMany()
                        .HasForeignKey("RegistrationCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Citizenship");

                    b.Navigation("LivingCity");

                    b.Navigation("RegistrationCity");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.DepositContract", b =>
                {
                    b.HasOne("DaDoIS.Data.Entities.Client", "Client")
                        .WithMany("DepositContracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("DaDoIS.Data.Entities.Deposit", "Deposit")
                        .WithMany()
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.TransitLog", b =>
                {
                    b.HasOne("DaDoIS.Data.Entities.BankAccount", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("DaDoIS.Data.Entities.BankAccount", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Source");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("DaDoIS.Data.Entities.Client", b =>
                {
                    b.Navigation("DepositContracts");
                });
#pragma warning restore 612, 618
        }
    }
}
