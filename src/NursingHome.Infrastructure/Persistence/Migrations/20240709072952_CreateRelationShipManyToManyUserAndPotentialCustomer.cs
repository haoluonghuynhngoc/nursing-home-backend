using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationShipManyToManyUserAndPotentialCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PotentialCustomerUser",
                columns: table => new
                {
                    PotentialCustomersId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialCustomerUser", x => new { x.PotentialCustomersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PotentialCustomerUser_PotentialCustomers_PotentialCustomersId",
                        column: x => x.PotentialCustomersId,
                        principalTable: "PotentialCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotentialCustomerUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialCustomerUser_UsersId",
                table: "PotentialCustomerUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotentialCustomerUser");
        }
    }
}
