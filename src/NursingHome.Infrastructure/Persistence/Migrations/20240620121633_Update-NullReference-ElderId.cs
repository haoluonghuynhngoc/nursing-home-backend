using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNullReferenceElderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Elders_ElderId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ElderId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Elders_ElderId",
                table: "Orders",
                column: "ElderId",
                principalTable: "Elders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Elders_ElderId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ElderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Elders_ElderId",
                table: "Orders",
                column: "ElderId",
                principalTable: "Elders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
