using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CareSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Blocks");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "HealthCategories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Rooms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Rooms",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Rooms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "Rooms",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Rooms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "HealthCategories",
                keyColumn: "ImageUrl",
                keyValue: null,
                column: "ImageUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "HealthCategories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CareSchedules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CareSchedules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "CareSchedules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CareSchedules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "CareSchedules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CareSchedules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Blocks",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Blocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Blocks",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Blocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "Blocks",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Blocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
