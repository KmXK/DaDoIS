using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaDoIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Deposits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizenship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<double>(type: "float", nullable: false),
                    IsRevocable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PassportSeries = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    PassportNumber = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    PassportIssuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivingCityId = table.Column<int>(type: "int", nullable: false),
                    LivingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationCityId = table.Column<int>(type: "int", nullable: false),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    CitizenshipId = table.Column<int>(type: "int", nullable: false),
                    DisabilityGroup = table.Column<int>(type: "int", nullable: false),
                    IsRetired = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    IsLiableForMilitaryService = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_LivingCityId",
                        column: x => x.LivingCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Cities_RegistrationCityId",
                        column: x => x.RegistrationCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Citizenship_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Citizenship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepositContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositId = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositContracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepositContracts_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransitLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransitLogs_BankAccounts_SourceId",
                        column: x => x.SourceId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransitLogs_BankAccounts_TargetId",
                        column: x => x.TargetId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CurrencyId",
                table: "BankAccounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CitizenshipId",
                table: "Clients",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LivingCityId",
                table: "Clients",
                column: "LivingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RegistrationCityId",
                table: "Clients",
                column: "RegistrationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_ClientId",
                table: "DepositContracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_DepositId",
                table: "DepositContracts",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_TransitLogs_SourceId",
                table: "TransitLogs",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransitLogs_TargetId",
                table: "TransitLogs",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositContracts");

            migrationBuilder.DropTable(
                name: "TransitLogs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Citizenship");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
