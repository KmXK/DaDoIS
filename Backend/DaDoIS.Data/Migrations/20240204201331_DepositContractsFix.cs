using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaDoIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class DepositContractsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysToEnd",
                table: "DepositContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DepositContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysToEnd",
                table: "DepositContracts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DepositContracts");
        }
    }
}
