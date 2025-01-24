using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_HomeTranslations_HomeId_Locale",
                schema: "dbo",
                table: "HomeTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTranslations_CategoryId_Locale",
                schema: "dbo",
                table: "CategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_BannerTranslations_BannerId_Locale",
                schema: "dbo",
                table: "BannerTranslations");

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

            migrationBuilder.CreateIndex(
                name: "IX_HomeTranslations_HomeId",
                schema: "dbo",
                table: "HomeTranslations",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                schema: "dbo",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerTranslations_BannerId",
                schema: "dbo",
                table: "BannerTranslations",
                column: "BannerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_HomeTranslations_HomeId",
                schema: "dbo",
                table: "HomeTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTranslations_CategoryId",
                schema: "dbo",
                table: "CategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_BannerTranslations_BannerId",
                schema: "dbo",
                table: "BannerTranslations");

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

            migrationBuilder.CreateIndex(
                name: "IX_HomeTranslations_HomeId_Locale",
                schema: "dbo",
                table: "HomeTranslations",
                columns: new[] { "HomeId", "Locale" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId_Locale",
                schema: "dbo",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "Locale" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerTranslations_BannerId_Locale",
                schema: "dbo",
                table: "BannerTranslations",
                columns: new[] { "BannerId", "Locale" },
                unique: true);
        }
    }
}
