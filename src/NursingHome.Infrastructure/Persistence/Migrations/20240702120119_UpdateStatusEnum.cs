using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OrderDetails",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OrderDates",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Ratings",
                table: "Feedbacks",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Contracts",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "OrderDates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "Ratings",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Contracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }
    }
}
