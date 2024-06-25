using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderAndNursingPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_NursingPackages_NursingPackageId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_NursingPackageId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NursingPackageId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NursingPackageId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NursingPackageId",
                table: "Orders",
                column: "NursingPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_NursingPackages_NursingPackageId",
                table: "Orders",
                column: "NursingPackageId",
                principalTable: "NursingPackages",
                principalColumn: "Id");
        }
    }
}
