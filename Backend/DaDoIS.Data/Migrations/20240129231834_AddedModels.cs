using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaDoIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedModels : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Citizenship");
        }
    }
}
