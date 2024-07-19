using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShiftAndNurseSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseSchedules_Shifts_ShiftId",
                table: "NurseSchedules");

            migrationBuilder.DropIndex(
                name: "IX_NurseSchedules_ShiftId",
                table: "NurseSchedules");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "NurseSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "NurseSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedules_ShiftId",
                table: "NurseSchedules",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseSchedules_Shifts_ShiftId",
                table: "NurseSchedules",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
