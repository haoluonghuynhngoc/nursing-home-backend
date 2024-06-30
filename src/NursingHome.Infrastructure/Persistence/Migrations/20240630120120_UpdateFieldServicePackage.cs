using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldServicePackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ServicePackages");

            migrationBuilder.DropColumn(
                name: "OccurrenceDay",
                table: "ServicePackageDates");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EventDate",
                table: "ServicePackages",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "ServicePackages");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "ServicePackages",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "OccurrenceDay",
                table: "ServicePackageDates",
                type: "date",
                nullable: true);
        }
    }
}
