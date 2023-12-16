using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.API.Migrations
{
    public partial class purchaseLineProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PurchaseLineItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLineItems_ProductId",
                table: "PurchaseLineItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLineItems_Products_ProductId",
                table: "PurchaseLineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLineItems_Products_ProductId",
                table: "PurchaseLineItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseLineItems_ProductId",
                table: "PurchaseLineItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseLineItems");
        }
    }
}
