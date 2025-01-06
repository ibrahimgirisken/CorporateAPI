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
                name: "FK_ModuleTranslations_Module_ModuleId",
                schema: "dbo",
                table: "ModuleTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                schema: "dbo",
                table: "Module");

            migrationBuilder.RenameTable(
                name: "Module",
                schema: "dbo",
                newName: "Modules",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                schema: "dbo",
                table: "Modules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Banners",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesktopImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableteImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BannerTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Locale = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerTranslations_Banners_BannerId",
                        column: x => x.BannerId,
                        principalSchema: "dbo",
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerTranslations_BannerId_Locale",
                schema: "dbo",
                table: "BannerTranslations",
                columns: new[] { "BannerId", "Locale" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleTranslations_Modules_ModuleId",
                schema: "dbo",
                table: "ModuleTranslations",
                column: "ModuleId",
                principalSchema: "dbo",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleTranslations_Modules_ModuleId",
                schema: "dbo",
                table: "ModuleTranslations");

            migrationBuilder.DropTable(
                name: "BannerTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Banners",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                schema: "dbo",
                table: "Modules");

            migrationBuilder.RenameTable(
                name: "Modules",
                schema: "dbo",
                newName: "Module",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                schema: "dbo",
                table: "Module",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleTranslations_Module_ModuleId",
                schema: "dbo",
                table: "ModuleTranslations",
                column: "ModuleId",
                principalSchema: "dbo",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
