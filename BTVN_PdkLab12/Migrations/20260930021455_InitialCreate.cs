using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTVN_PdkLab12.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdkCategories",
                columns: table => new
                {
                    PdkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdkStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PdkCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdkCategories", x => x.PdkId);
                });

            migrationBuilder.CreateTable(
                name: "PdkProducts",
                columns: table => new
                {
                    PdkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdkName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PdkImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdkPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PdkSalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PdkStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PdkDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdkCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PdkCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdkProducts", x => x.PdkId);
                    table.ForeignKey(
                        name: "FK_PdkProducts_PdkCategories_PdkCategoryId",
                        column: x => x.PdkCategoryId,
                        principalTable: "PdkCategories",
                        principalColumn: "PdkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdkProducts_PdkCategoryId",
                table: "PdkProducts",
                column: "PdkCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdkProducts");

            migrationBuilder.DropTable(
                name: "PdkCategories");
        }
    }
}
