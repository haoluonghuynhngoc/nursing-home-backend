using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationShipUserAndPotentialCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PotentialCustomers_Users_UserId",
                table: "PotentialCustomers");

            migrationBuilder.DropIndex(
                name: "IX_PotentialCustomers_UserId",
                table: "PotentialCustomers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PotentialCustomers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PotentialCustomers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialCustomers_UserId",
                table: "PotentialCustomers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PotentialCustomers_Users_UserId",
                table: "PotentialCustomers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
