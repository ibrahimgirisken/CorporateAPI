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
            migrationBuilder.DropIndex(
                name: "IX_CategoryTranslations_CategoryId",
                schema: "dbo",
                table: "CategoryTranslations");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId_Locale",
                schema: "dbo",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "Locale" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryTranslations_CategoryId_Locale",
                schema: "dbo",
                table: "CategoryTranslations");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                schema: "dbo",
                table: "CategoryTranslations",
                column: "CategoryId");
        }
    }
}
