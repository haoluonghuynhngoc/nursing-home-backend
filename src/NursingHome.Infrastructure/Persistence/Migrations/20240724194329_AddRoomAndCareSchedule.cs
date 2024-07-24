using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomAndCareSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareScheduleRoom",
                columns: table => new
                {
                    CareSchedulesId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareScheduleRoom", x => new { x.CareSchedulesId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_CareScheduleRoom_CareSchedules_CareSchedulesId",
                        column: x => x.CareSchedulesId,
                        principalTable: "CareSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareScheduleRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CareScheduleRoom_RoomsId",
                table: "CareScheduleRoom",
                column: "RoomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareScheduleRoom");
        }
    }
}
