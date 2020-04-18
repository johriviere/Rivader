using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class CulturedLabelsUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CulturedLabels_TranslationId",
                schema: "dbo",
                table: "CulturedLabels");

            migrationBuilder.CreateIndex(
                name: "IX_CulturedLabels_TranslationId_Lcid",
                schema: "dbo",
                table: "CulturedLabels",
                columns: new[] { "TranslationId", "Lcid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CulturedLabels_TranslationId_Lcid",
                schema: "dbo",
                table: "CulturedLabels");

            migrationBuilder.CreateIndex(
                name: "IX_CulturedLabels_TranslationId",
                schema: "dbo",
                table: "CulturedLabels",
                column: "TranslationId");
        }
    }
}
