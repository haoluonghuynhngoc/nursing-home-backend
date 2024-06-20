using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NursingHome.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateDiseaseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Move",
                table: "MedicalRecords",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCategory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseCategoryMedicalRecord",
                columns: table => new
                {
                    DiseaseCategoriesId = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCategoryMedicalRecord", x => new { x.DiseaseCategoriesId, x.MedicalRecordsId });
                    table.ForeignKey(
                        name: "FK_DiseaseCategoryMedicalRecord_DiseaseCategory_DiseaseCategori~",
                        column: x => x.DiseaseCategoriesId,
                        principalTable: "DiseaseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseCategoryMedicalRecord_MedicalRecords_MedicalRecordsId",
                        column: x => x.MedicalRecordsId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCategoryMedicalRecord_MedicalRecordsId",
                table: "DiseaseCategoryMedicalRecord",
                column: "MedicalRecordsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseCategoryMedicalRecord");

            migrationBuilder.DropTable(
                name: "DiseaseCategory");

            migrationBuilder.DropColumn(
                name: "Move",
                table: "MedicalRecords");
        }
    }
}
