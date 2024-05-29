using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Packages_PackageId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Elders_Beds_BedId",
                table: "Elders");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Elders_BedId",
                table: "Elders");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_PackageId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "Elders");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Contracts");

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
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Packages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Packages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Elders",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Elders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Elders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareScheduleTasks",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

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
                name: "IX_Elders_RoomId",
                table: "Elders",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseElders_ElderId",
                table: "NurseElders",
                column: "ElderId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseElders_UserId",
                table: "NurseElders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elders_Rooms_RoomId",
                table: "Elders",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elders_Rooms_RoomId",
                table: "Elders");

            migrationBuilder.DropTable(
                name: "NurseElders");

            migrationBuilder.DropIndex(
                name: "IX_Elders_RoomId",
                table: "Elders");

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

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Elders");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Elders");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Rooms",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PackageTypes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Elders",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "Elders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "Contracts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareScheduleTasks",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Elders_BedId",
                table: "Elders",
                column: "BedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PackageId",
                table: "Contracts",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Packages_PackageId",
                table: "Contracts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elders_Beds_BedId",
                table: "Elders",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserId",
                table: "Rooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
