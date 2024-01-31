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
    [Migration("20240129231834_AddedModels")]
    partial class AddedModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DaDoIS.Data.Models.Citizenship", b =>
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

            modelBuilder.Entity("DaDoIS.Data.Models.City", b =>
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

            modelBuilder.Entity("DaDoIS.Data.Models.Client", b =>
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

            modelBuilder.Entity("DaDoIS.Data.Models.Client", b =>
                {
                    b.HasOne("DaDoIS.Data.Models.Citizenship", "Citizenship")
                        .WithMany()
                        .HasForeignKey("CitizenshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaDoIS.Data.Models.City", "LivingCity")
                        .WithMany()
                        .HasForeignKey("LivingCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DaDoIS.Data.Models.City", "RegistrationCity")
                        .WithMany()
                        .HasForeignKey("RegistrationCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Citizenship");

                    b.Navigation("LivingCity");

                    b.Navigation("RegistrationCity");
                });
#pragma warning restore 612, 618
        }
    }
}
