using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInServicePackageDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ServicePackageDates",
                newName: "OccurrenceDay");

            migrationBuilder.AddColumn<int>(
                name: "RepetitionDay",
                table: "ServicePackageDates",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepetitionDay",
                table: "ServicePackageDates");

            migrationBuilder.RenameColumn(
                name: "OccurrenceDay",
                table: "ServicePackageDates",
                newName: "Date");
        }
    }
}
