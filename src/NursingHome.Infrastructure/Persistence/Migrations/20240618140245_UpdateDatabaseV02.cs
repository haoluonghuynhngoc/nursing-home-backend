using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NursingPackageId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NursingPackageId",
                table: "Appointments",
                column: "NursingPackageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_NursingPackages_NursingPackageId",
                table: "Appointments",
                column: "NursingPackageId",
                principalTable: "NursingPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_NursingPackages_NursingPackageId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_NursingPackageId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NursingPackageId",
                table: "Appointments");
        }
    }
}
