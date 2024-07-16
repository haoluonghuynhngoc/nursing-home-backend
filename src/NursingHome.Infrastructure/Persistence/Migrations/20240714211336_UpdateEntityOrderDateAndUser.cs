using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityOrderDateAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "OrderDates",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "OrderDates",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDates_UserId",
                table: "OrderDates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDates_Users_UserId",
                table: "OrderDates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDates_Users_UserId",
                table: "OrderDates");

            migrationBuilder.DropIndex(
                name: "IX_OrderDates_UserId",
                table: "OrderDates");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "OrderDates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderDates");
        }
    }
}
