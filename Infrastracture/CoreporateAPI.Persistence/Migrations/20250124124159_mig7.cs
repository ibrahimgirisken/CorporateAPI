using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
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

            migrationBuilder.CreateTable(
                name: "Datasheet",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datasheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatasheetTranslation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatasheetId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasheetTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatasheetTranslation_Datasheet_DatasheetId",
                        column: x => x.DatasheetId,
                        principalSchema: "dbo",
                        principalTable: "Datasheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DatasheetTranslation_Languages_Locale",
                        column: x => x.Locale,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "LangCode",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DatasheetTranslation_DatasheetId_Locale",
                schema: "dbo",
                table: "DatasheetTranslation",
                columns: new[] { "DatasheetId", "Locale" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatasheetTranslation_Locale",
                schema: "dbo",
                table: "DatasheetTranslation",
                column: "Locale");

            migrationBuilder.CreateIndex(
                name: "IX_DatasheetTranslation_Url",
                schema: "dbo",
                table: "DatasheetTranslation",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatasheetTranslation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Datasheet",
                schema: "dbo");

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
    }
}
