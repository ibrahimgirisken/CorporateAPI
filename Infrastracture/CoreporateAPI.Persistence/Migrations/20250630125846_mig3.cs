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
                name: "FK_TranslationValues_TranslationKey_TranslationKeyId",
                schema: "dbo",
                table: "TranslationValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslationKey",
                schema: "dbo",
                table: "TranslationKey");

            migrationBuilder.RenameTable(
                name: "TranslationKey",
                schema: "dbo",
                newName: "TranslationKeys",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "dbo",
                table: "TranslationKeys",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslationKeys",
                schema: "dbo",
                table: "TranslationKeys",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationKeys_Key",
                schema: "dbo",
                table: "TranslationKeys",
                column: "Key",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationValues_TranslationKeys_TranslationKeyId",
                schema: "dbo",
                table: "TranslationValues",
                column: "TranslationKeyId",
                principalSchema: "dbo",
                principalTable: "TranslationKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslationValues_TranslationKeys_TranslationKeyId",
                schema: "dbo",
                table: "TranslationValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslationKeys",
                schema: "dbo",
                table: "TranslationKeys");

            migrationBuilder.DropIndex(
                name: "IX_TranslationKeys_Key",
                schema: "dbo",
                table: "TranslationKeys");

            migrationBuilder.RenameTable(
                name: "TranslationKeys",
                schema: "dbo",
                newName: "TranslationKey",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "dbo",
                table: "TranslationKey",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslationKey",
                schema: "dbo",
                table: "TranslationKey",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationValues_TranslationKey_TranslationKeyId",
                schema: "dbo",
                table: "TranslationValues",
                column: "TranslationKeyId",
                principalSchema: "dbo",
                principalTable: "TranslationKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
