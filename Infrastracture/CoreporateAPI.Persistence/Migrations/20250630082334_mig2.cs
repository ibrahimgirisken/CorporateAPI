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
            migrationBuilder.CreateTable(
                name: "TranslationKey",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationValues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslationKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationValues_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranslationValues_TranslationKey_TranslationKeyId",
                        column: x => x.TranslationKeyId,
                        principalSchema: "dbo",
                        principalTable: "TranslationKey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslationValues_LangId",
                schema: "dbo",
                table: "TranslationValues",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationValues_TranslationKeyId_LangId",
                schema: "dbo",
                table: "TranslationValues",
                columns: new[] { "TranslationKeyId", "LangId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationValues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TranslationKey",
                schema: "dbo");
        }
    }
}
