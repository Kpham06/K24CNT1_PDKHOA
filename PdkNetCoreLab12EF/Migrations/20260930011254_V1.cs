using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdkNetCoreLab12EF.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdkCategory",
                columns: table => new
                {
                    PdkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdkName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PdkStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PdkCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdkCategory", x => x.PdkId);
                });

            migrationBuilder.CreateTable(
                name: "PdkProduct",
                columns: table => new
                {
                    PdkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdkName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PdkImage = table.Column<string>(type: "varchar(150)", nullable: true),
                    PdkPrice = table.Column<float>(type: "real", nullable: false),
                    PdkSalePrice = table.Column<float>(type: "real", nullable: false),
                    PdkStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PdkDescriptions = table.Column<string>(type: "ntext", maxLength: 1000, nullable: true),
                    PdkCategoryId = table.Column<int>(type: "int", nullable: false),
                    PdkCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdkProduct", x => x.PdkId);
                    table.ForeignKey(
                        name: "FK_PdkProduct_PdkCategory_PdkCategoryId",
                        column: x => x.PdkCategoryId,
                        principalTable: "PdkCategory",
                        principalColumn: "PdkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdkProduct_PdkCategoryId",
                table: "PdkProduct",
                column: "PdkCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdkProduct");

            migrationBuilder.DropTable(
                name: "PdkCategory");
        }
    }
}
