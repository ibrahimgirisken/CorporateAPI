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
            migrationBuilder.DropIndex(
                name: "IX_PageTranslations_PageId",
                schema: "dbo",
                table: "PageTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ModuleTranslations_ModuleId",
                schema: "dbo",
                table: "ModuleTranslations");

            migrationBuilder.DropIndex(
                name: "IX_MenuTranslations_MenuId",
                schema: "dbo",
                table: "MenuTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "PageTranslations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "ModuleTranslations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "MenuTranslations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId_Locale",
                schema: "dbo",
                table: "PageTranslations",
                columns: new[] { "PageId", "Locale" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTranslations_ModuleId_Locale",
                schema: "dbo",
                table: "ModuleTranslations",
                columns: new[] { "ModuleId", "Locale" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuTranslations_MenuId_Locale",
                schema: "dbo",
                table: "MenuTranslations",
                columns: new[] { "MenuId", "Locale" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageTranslations_PageId_Locale",
                schema: "dbo",
                table: "PageTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ModuleTranslations_ModuleId_Locale",
                schema: "dbo",
                table: "ModuleTranslations");

            migrationBuilder.DropIndex(
                name: "IX_MenuTranslations_MenuId_Locale",
                schema: "dbo",
                table: "MenuTranslations");

            migrationBuilder.DropColumn(
                name: "Locale",
                schema: "dbo",
                table: "MenuTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "PageTranslations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "ModuleTranslations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId",
                schema: "dbo",
                table: "PageTranslations",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTranslations_ModuleId",
                schema: "dbo",
                table: "ModuleTranslations",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTranslations_MenuId",
                schema: "dbo",
                table: "MenuTranslations",
                column: "MenuId");
        }
    }
}
