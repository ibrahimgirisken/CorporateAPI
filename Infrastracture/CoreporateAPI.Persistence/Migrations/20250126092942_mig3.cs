using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannerTranslations_Files_BannerId",
                schema: "dbo",
                table: "BannerTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "EntityModel",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileType",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "dbo",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Files",
                schema: "dbo",
                newName: "Banners",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "Banners",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Banners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banners",
                schema: "dbo",
                table: "Banners",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannerTranslations_Banners_BannerId",
                schema: "dbo",
                table: "BannerTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banners",
                schema: "dbo",
                table: "Banners");

            migrationBuilder.RenameTable(
                name: "Banners",
                schema: "dbo",
                newName: "Files",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "Files",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Files",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntityModel",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "dbo",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                schema: "dbo",
                table: "Files",
                column: "Id");

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
    }
}
