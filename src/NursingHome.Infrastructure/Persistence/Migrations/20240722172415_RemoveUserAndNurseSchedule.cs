using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserAndNurseSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseSchedules_Users_UserId",
                table: "NurseSchedules");

            migrationBuilder.DropIndex(
                name: "IX_NurseSchedules_UserId",
                table: "NurseSchedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NurseSchedules");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CareSchedules");

            migrationBuilder.AddColumn<int>(
                name: "CareMonth",
                table: "CareSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CareYear",
                table: "CareSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareMonth",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "CareYear",
                table: "CareSchedules");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "NurseSchedules",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "CareSchedules",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedules_UserId",
                table: "NurseSchedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseSchedules_Users_UserId",
                table: "NurseSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
