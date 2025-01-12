using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageTranslations_PageId_Locale",
                schema: "dbo",
                table: "PageTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "PageTranslations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId_Locale",
                schema: "dbo",
                table: "PageTranslations",
                columns: new[] { "PageId", "Locale" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageTranslations_PageId_Locale",
                schema: "dbo",
                table: "PageTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                schema: "dbo",
                table: "PageTranslations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId_Locale",
                schema: "dbo",
                table: "PageTranslations",
                columns: new[] { "PageId", "Locale" },
                unique: true,
                filter: "[Locale] IS NOT NULL");
        }
    }
}
