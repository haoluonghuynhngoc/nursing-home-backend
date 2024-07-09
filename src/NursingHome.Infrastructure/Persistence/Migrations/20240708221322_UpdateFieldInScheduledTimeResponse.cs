using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldInScheduledTimeResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledServiceDetails_Elders_ElderId",
                table: "ScheduledServiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledServiceDetails_ServicePackages_ServicePackageId",
                table: "ScheduledServiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledTimes_ScheduledServiceDetails_ScheduledServiceDetai~",
                table: "ScheduledTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledTimes_ScheduledServices_ScheduledServiceId",
                table: "ScheduledTimes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledTimes_ScheduledServiceId",
                table: "ScheduledTimes");

            migrationBuilder.DropColumn(
                name: "ScheduledServiceId",
                table: "ScheduledTimes");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledServiceDetailId",
                table: "ScheduledTimes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServicePackageId",
                table: "ScheduledServiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ElderId",
                table: "ScheduledServiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledServiceDetails_Elders_ElderId",
                table: "ScheduledServiceDetails",
                column: "ElderId",
                principalTable: "Elders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledServiceDetails_ServicePackages_ServicePackageId",
                table: "ScheduledServiceDetails",
                column: "ServicePackageId",
                principalTable: "ServicePackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledTimes_ScheduledServiceDetails_ScheduledServiceDetai~",
                table: "ScheduledTimes",
                column: "ScheduledServiceDetailId",
                principalTable: "ScheduledServiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledServiceDetails_Elders_ElderId",
                table: "ScheduledServiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledServiceDetails_ServicePackages_ServicePackageId",
                table: "ScheduledServiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledTimes_ScheduledServiceDetails_ScheduledServiceDetai~",
                table: "ScheduledTimes");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledServiceDetailId",
                table: "ScheduledTimes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ScheduledServiceId",
                table: "ScheduledTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServicePackageId",
                table: "ScheduledServiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ElderId",
                table: "ScheduledServiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTimes_ScheduledServiceId",
                table: "ScheduledTimes",
                column: "ScheduledServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledServiceDetails_Elders_ElderId",
                table: "ScheduledServiceDetails",
                column: "ElderId",
                principalTable: "Elders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledServiceDetails_ServicePackages_ServicePackageId",
                table: "ScheduledServiceDetails",
                column: "ServicePackageId",
                principalTable: "ServicePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledTimes_ScheduledServiceDetails_ScheduledServiceDetai~",
                table: "ScheduledTimes",
                column: "ScheduledServiceDetailId",
                principalTable: "ScheduledServiceDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledTimes_ScheduledServices_ScheduledServiceId",
                table: "ScheduledTimes",
                column: "ScheduledServiceId",
                principalTable: "ScheduledServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
