using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateForeignKeyAboutAppointmentAndContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ContractId",
                table: "Appointments",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Contracts_ContractId",
                table: "Appointments",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Contracts_ContractId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ContractId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Appointments");
        }
    }
}
