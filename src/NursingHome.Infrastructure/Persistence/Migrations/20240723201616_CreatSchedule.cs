using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseScheduleShift");

            migrationBuilder.DropTable(
                name: "UserNurseSchedules");

            migrationBuilder.DropTable(
                name: "NurseSchedules");

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MonthlyCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateInMonth = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCalendars", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MonthlyCalendarDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MonthlyCalendarId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCalendarDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyCalendarDetails_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyCalendarDetails_MonthlyCalendars_MonthlyCalendarId",
                        column: x => x.MonthlyCalendarId,
                        principalTable: "MonthlyCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeTypeId",
                table: "EmployeeSchedules",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_UserId",
                table: "EmployeeSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCalendarDetails_EmployeeTypeId",
                table: "MonthlyCalendarDetails",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCalendarDetails_MonthlyCalendarId",
                table: "MonthlyCalendarDetails",
                column: "MonthlyCalendarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSchedules");

            migrationBuilder.DropTable(
                name: "MonthlyCalendarDetails");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "MonthlyCalendars");

            migrationBuilder.CreateTable(
                name: "NurseSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CareScheduleId = table.Column<int>(type: "int", nullable: false),
                    ShiftWorkerName = table.Column<string>(type: "nvarchar(24)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "UserNurseSchedules",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NurseScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNurseSchedules", x => new { x.UserId, x.NurseScheduleId });
                    table.ForeignKey(
                        name: "FK_UserNurseSchedules_NurseSchedules_NurseScheduleId",
                        column: x => x.NurseScheduleId,
                        principalTable: "NurseSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNurseSchedules_Users_UserId",
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
                name: "IX_NurseScheduleShift_ShiftsId",
                table: "NurseScheduleShift",
                column: "ShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNurseSchedules_NurseScheduleId",
                table: "UserNurseSchedules",
                column: "NurseScheduleId");
        }
    }
}
