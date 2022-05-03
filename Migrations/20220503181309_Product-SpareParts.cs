using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApplication.Migrations
{
    public partial class ProductSpareParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpareParts");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "SpareParts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_ProductId",
                table: "SpareParts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Products_ProductId",
                table: "SpareParts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Products_ProductId",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_ProductId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SpareParts");

            migrationBuilder.CreateTable(
                name: "ProductSpareParts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SparePartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpareParts", x => new { x.ProductId, x.SparePartId });
                    table.ForeignKey(
                        name: "FK_ProductSpareParts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpareParts_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpareParts_SparePartId",
                table: "ProductSpareParts",
                column: "SparePartId");
        }
    }
}
