using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldTmpIdNursingInContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_NursingPackages_NursingPackageId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "NursingPackageId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_NursingPackages_NursingPackageId",
                table: "Contracts",
                column: "NursingPackageId",
                principalTable: "NursingPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_NursingPackages_NursingPackageId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "NursingPackageId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_NursingPackages_NursingPackageId",
                table: "Contracts",
                column: "NursingPackageId",
                principalTable: "NursingPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
