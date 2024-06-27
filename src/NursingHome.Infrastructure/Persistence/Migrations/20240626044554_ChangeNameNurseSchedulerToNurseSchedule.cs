using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameNurseSchedulerToNurseSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseSchedulers");

            migrationBuilder.CreateTable(
                name: "NurseSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CareScheduleId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseSchedules_CareSchedules_CareScheduleId",
                        column: x => x.CareScheduleId,
                        principalTable: "CareSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseSchedules_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseSchedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedules_CareScheduleId",
                table: "NurseSchedules",
                column: "CareScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedules_ShiftId",
                table: "NurseSchedules",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedules_UserId",
                table: "NurseSchedules",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseSchedules");

            migrationBuilder.CreateTable(
                name: "NurseSchedulers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CareScheduleId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseSchedulers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseSchedulers_CareSchedules_CareScheduleId",
                        column: x => x.CareScheduleId,
                        principalTable: "CareSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseSchedulers_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseSchedulers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedulers_CareScheduleId",
                table: "NurseSchedulers",
                column: "CareScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedulers_ShiftId",
                table: "NurseSchedulers",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedulers_UserId",
                table: "NurseSchedulers",
                column: "UserId");
        }
    }
}
