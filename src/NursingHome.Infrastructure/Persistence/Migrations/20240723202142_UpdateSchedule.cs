using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareScheduleId",
                table: "EmployeeSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MonthlyCalendarDetailShift",
                columns: table => new
                {
                    NurseSchedulersId = table.Column<int>(type: "int", nullable: false),
                    ShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCalendarDetailShift", x => new { x.NurseSchedulersId, x.ShiftsId });
                    table.ForeignKey(
                        name: "FK_MonthlyCalendarDetailShift_MonthlyCalendarDetails_NurseSched~",
                        column: x => x.NurseSchedulersId,
                        principalTable: "MonthlyCalendarDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyCalendarDetailShift_Shifts_ShiftsId",
                        column: x => x.ShiftsId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_CareScheduleId",
                table: "EmployeeSchedules",
                column: "CareScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCalendarDetailShift_ShiftsId",
                table: "MonthlyCalendarDetailShift",
                column: "ShiftsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_CareSchedules_CareScheduleId",
                table: "EmployeeSchedules",
                column: "CareScheduleId",
                principalTable: "CareSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_CareSchedules_CareScheduleId",
                table: "EmployeeSchedules");

            migrationBuilder.DropTable(
                name: "MonthlyCalendarDetailShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSchedules_CareScheduleId",
                table: "EmployeeSchedules");

            migrationBuilder.DropColumn(
                name: "CareScheduleId",
                table: "EmployeeSchedules");
        }
    }
}
