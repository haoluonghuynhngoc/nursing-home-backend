using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityContractNursingPackageAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NursingPackageId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractId",
                table: "Orders",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_NursingPackageId",
                table: "Contracts",
                column: "NursingPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_NursingPackages_NursingPackageId",
                table: "Contracts",
                column: "NursingPackageId",
                principalTable: "NursingPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contracts_ContractId",
                table: "Orders",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_NursingPackages_NursingPackageId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contracts_ContractId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContractId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_NursingPackageId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NursingPackageId",
                table: "Contracts");
        }
    }
}
