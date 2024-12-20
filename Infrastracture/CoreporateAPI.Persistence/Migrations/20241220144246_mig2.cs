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
            migrationBuilder.AddColumn<string>(
                name: "Brief",
                schema: "dbo",
                table: "PageTranslation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "PageTranslation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "dbo",
                table: "PageTranslation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                schema: "dbo",
                table: "PageTranslation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "dbo",
                table: "PageTranslation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                schema: "dbo",
                table: "Page",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                schema: "dbo",
                table: "Page",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                schema: "dbo",
                table: "Page",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Page",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brief",
                schema: "dbo",
                table: "PageTranslation");

            migrationBuilder.DropColumn(
                name: "Content",
                schema: "dbo",
                table: "PageTranslation");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "dbo",
                table: "PageTranslation");

            migrationBuilder.DropColumn(
                name: "PageTitle",
                schema: "dbo",
                table: "PageTranslation");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "dbo",
                table: "PageTranslation");

            migrationBuilder.DropColumn(
                name: "Image1",
                schema: "dbo",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Image2",
                schema: "dbo",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Image3",
                schema: "dbo",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "dbo",
                table: "Page");
        }
    }
}
