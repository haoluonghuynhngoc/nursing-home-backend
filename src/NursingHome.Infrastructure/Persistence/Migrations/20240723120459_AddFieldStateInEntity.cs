using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldStateInEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "ServicePackages",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "ServicePackageCategories",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "PotentialCustomers",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "NursingPackages",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "ServicePackages");

            migrationBuilder.DropColumn(
                name: "State",
                table: "ServicePackageCategories");

            migrationBuilder.DropColumn(
                name: "State",
                table: "PotentialCustomers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "NursingPackages");
        }
    }
}
