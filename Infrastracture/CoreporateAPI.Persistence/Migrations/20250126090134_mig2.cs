using System;
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
                name: "FK_BannerTranslations_Banners_BannerId",
                schema: "dbo",
                table: "BannerTranslations");

            migrationBuilder.DropTable(
                name: "Banners",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "DesktopImage",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesktopVideo",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileImage",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileVideo",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "Files",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableteImage",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BannerTranslations_Files_BannerId",
                schema: "dbo",
                table: "BannerTranslations",
                column: "BannerId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannerTranslations_Files_BannerId",
                schema: "dbo",
                table: "BannerTranslations");

            migrationBuilder.DropColumn(
                name: "DesktopImage",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DesktopVideo",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "MobileImage",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "MobileVideo",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "TableteImage",
                schema: "dbo",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "Banners",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesktopImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesktopVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MobileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TableteImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BannerTranslations_Banners_BannerId",
                schema: "dbo",
                table: "BannerTranslations",
                column: "BannerId",
                principalSchema: "dbo",
                principalTable: "Banners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
