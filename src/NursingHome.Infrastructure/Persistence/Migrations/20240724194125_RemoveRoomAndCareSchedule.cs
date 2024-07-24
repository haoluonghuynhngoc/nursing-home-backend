using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoomAndCareSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareSchedules_Rooms_RoomId",
                table: "CareSchedules");

            migrationBuilder.DropIndex(
                name: "IX_CareSchedules_RoomId",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "CareSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "CareSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CareSchedules_RoomId",
                table: "CareSchedules",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareSchedules_Rooms_RoomId",
                table: "CareSchedules",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
