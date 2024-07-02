using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftNameStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shifts",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shifts");
        }
    }
}
