using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "nvarchar(24)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(24)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalBed",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnusedBed",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserBed",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PackageTypes",
                type: "nvarchar(24)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Elders",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NurseElders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DutyDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    ElderId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseElders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseElders_Elders_ElderId",
                        column: x => x.ElderId,
                        principalTable: "Elders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseElders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NurseElders_ElderId",
                table: "NurseElders",
                column: "ElderId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseElders_UserId",
                table: "NurseElders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseElders");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TotalBed",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UnusedBed",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserBed",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PackageTypes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Elders",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }
    }
}
