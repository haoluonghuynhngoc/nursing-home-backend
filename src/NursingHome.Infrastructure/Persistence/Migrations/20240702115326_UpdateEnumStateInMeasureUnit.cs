using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnumStateInMeasureUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "MeasureUnits",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "MeasureUnits",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }
    }
}
