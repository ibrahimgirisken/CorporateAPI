using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                schema: "dbo",
                table: "Product",
                column: "BrandId",
                principalSchema: "dbo",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                schema: "dbo",
                table: "Product",
                column: "BrandId",
                principalSchema: "dbo",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
