using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePackageServiceAndNursingPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Orders_OrderId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDates_Orders_OrderId",
                table: "OrderDates");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contracts_ContractId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Elders_ElderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ServicePackages_ServicePackageId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContractId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ElderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServicePackageId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDates_OrderId",
                table: "OrderDates");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_OrderId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ElderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ServicePackageId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDates",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Feedbacks",
                newName: "OrderDetailId");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicePackageId = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    ElderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Elders_ElderId",
                        column: x => x.ElderId,
                        principalTable: "Elders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_ServicePackages_ServicePackageId",
                        column: x => x.ServicePackageId,
                        principalTable: "ServicePackages",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDates_OrderDetailId",
                table: "OrderDates",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OrderDetailId",
                table: "Feedbacks",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ContractId",
                table: "OrderDetails",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ElderId",
                table: "OrderDetails",
                column: "ElderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServicePackageId",
                table: "OrderDetails",
                column: "ServicePackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_OrderDetails_OrderDetailId",
                table: "Feedbacks",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDates_OrderDetails_OrderDetailId",
                table: "OrderDates",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_OrderDetails_OrderDetailId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDates_OrderDetails_OrderDetailId",
                table: "OrderDates");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDates_OrderDetailId",
                table: "OrderDates");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_OrderDetailId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderDates");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderDates",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "Feedbacks",
                newName: "OrderId");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicePackageId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractId",
                table: "Orders",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ElderId",
                table: "Orders",
                column: "ElderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServicePackageId",
                table: "Orders",
                column: "ServicePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDates_OrderId",
                table: "OrderDates",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OrderId",
                table: "Feedbacks",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Orders_OrderId",
                table: "Feedbacks",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDates_Orders_OrderId",
                table: "OrderDates",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contracts_ContractId",
                table: "Orders",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Elders_ElderId",
                table: "Orders",
                column: "ElderId",
                principalTable: "Elders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ServicePackages_ServicePackageId",
                table: "Orders",
                column: "ServicePackageId",
                principalTable: "ServicePackages",
                principalColumn: "Id");
        }
    }
}
