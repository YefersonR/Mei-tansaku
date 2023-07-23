using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addingrelationsRubioLaCaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attribute_Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value_AttributeID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attribute_Product_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Attribute_Product_Value_attribute_Value_AttributeID",
                        column: x => x.Value_AttributeID,
                        principalTable: "Value_attribute",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Product_ProductID",
                table: "Attribute_Product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Product_Value_AttributeID",
                table: "Attribute_Product",
                column: "Value_AttributeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribute_Product");
        }
    }
}
