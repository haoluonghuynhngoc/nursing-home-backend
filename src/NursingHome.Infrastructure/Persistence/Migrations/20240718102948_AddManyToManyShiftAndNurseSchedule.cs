using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyShiftAndNurseSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NurseScheduleShift",
                columns: table => new
                {
                    NurseSchedulersId = table.Column<int>(type: "int", nullable: false),
                    ShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseScheduleShift", x => new { x.NurseSchedulersId, x.ShiftsId });
                    table.ForeignKey(
                        name: "FK_NurseScheduleShift_NurseSchedules_NurseSchedulersId",
                        column: x => x.NurseSchedulersId,
                        principalTable: "NurseSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseScheduleShift_Shifts_ShiftsId",
                        column: x => x.ShiftsId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NurseScheduleShift_ShiftsId",
                table: "NurseScheduleShift",
                column: "ShiftsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseScheduleShift");
        }
    }
}
