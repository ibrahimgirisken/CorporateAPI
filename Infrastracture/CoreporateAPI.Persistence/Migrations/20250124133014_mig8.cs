using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatasheetTranslation_Datasheet_DatasheetId",
                schema: "dbo",
                table: "DatasheetTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_DatasheetTranslation_Languages_Locale",
                schema: "dbo",
                table: "DatasheetTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatasheetTranslation",
                schema: "dbo",
                table: "DatasheetTranslation");

            migrationBuilder.RenameTable(
                name: "DatasheetTranslation",
                schema: "dbo",
                newName: "DatasheetTranslations",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_DatasheetTranslation_Url",
                schema: "dbo",
                table: "DatasheetTranslations",
                newName: "IX_DatasheetTranslations_Url");

            migrationBuilder.RenameIndex(
                name: "IX_DatasheetTranslation_Locale",
                schema: "dbo",
                table: "DatasheetTranslations",
                newName: "IX_DatasheetTranslations_Locale");

            migrationBuilder.RenameIndex(
                name: "IX_DatasheetTranslation_DatasheetId_Locale",
                schema: "dbo",
                table: "DatasheetTranslations",
                newName: "IX_DatasheetTranslations_DatasheetId_Locale");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatasheetTranslations",
                schema: "dbo",
                table: "DatasheetTranslations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatasheetTranslations_Datasheet_DatasheetId",
                schema: "dbo",
                table: "DatasheetTranslations",
                column: "DatasheetId",
                principalSchema: "dbo",
                principalTable: "Datasheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DatasheetTranslations_Languages_Locale",
                schema: "dbo",
                table: "DatasheetTranslations",
                column: "Locale",
                principalSchema: "dbo",
                principalTable: "Languages",
                principalColumn: "LangCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatasheetTranslations_Datasheet_DatasheetId",
                schema: "dbo",
                table: "DatasheetTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_DatasheetTranslations_Languages_Locale",
                schema: "dbo",
                table: "DatasheetTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatasheetTranslations",
                schema: "dbo",
                table: "DatasheetTranslations");

            migrationBuilder.RenameTable(
                name: "DatasheetTranslations",
                schema: "dbo",
                newName: "DatasheetTranslation",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_DatasheetTranslations_Url",
                schema: "dbo",
                table: "DatasheetTranslation",
                newName: "IX_DatasheetTranslation_Url");

            migrationBuilder.RenameIndex(
                name: "IX_DatasheetTranslations_Locale",
                schema: "dbo",
                table: "DatasheetTranslation",
                newName: "IX_DatasheetTranslation_Locale");

            migrationBuilder.RenameIndex(
                name: "IX_DatasheetTranslations_DatasheetId_Locale",
                schema: "dbo",
                table: "DatasheetTranslation",
                newName: "IX_DatasheetTranslation_DatasheetId_Locale");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatasheetTranslation",
                schema: "dbo",
                table: "DatasheetTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatasheetTranslation_Datasheet_DatasheetId",
                schema: "dbo",
                table: "DatasheetTranslation",
                column: "DatasheetId",
                principalSchema: "dbo",
                principalTable: "Datasheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DatasheetTranslation_Languages_Locale",
                schema: "dbo",
                table: "DatasheetTranslation",
                column: "Locale",
                principalSchema: "dbo",
                principalTable: "Languages",
                principalColumn: "LangCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
