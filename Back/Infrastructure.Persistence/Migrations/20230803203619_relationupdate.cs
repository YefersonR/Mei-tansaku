using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class relationupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_list_Shopping_List_Shopping_ListID",
                table: "Product_list");

            migrationBuilder.DropIndex(
                name: "IX_Product_list_Shopping_ListID",
                table: "Product_list");

            migrationBuilder.DropColumn(
                name: "Shopping_ListID",
                table: "Product_list");

            migrationBuilder.CreateIndex(
                name: "IX_Product_list_ShoppingListID",
                table: "Product_list",
                column: "ShoppingListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_list_Shopping_List_ShoppingListID",
                table: "Product_list",
                column: "ShoppingListID",
                principalTable: "Shopping_List",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_list_Shopping_List_ShoppingListID",
                table: "Product_list");

            migrationBuilder.DropIndex(
                name: "IX_Product_list_ShoppingListID",
                table: "Product_list");

            migrationBuilder.AddColumn<int>(
                name: "Shopping_ListID",
                table: "Product_list",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_list_Shopping_ListID",
                table: "Product_list",
                column: "Shopping_ListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_list_Shopping_List_Shopping_ListID",
                table: "Product_list",
                column: "Shopping_ListID",
                principalTable: "Shopping_List",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
