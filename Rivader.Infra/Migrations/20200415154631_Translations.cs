using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class Translations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Translations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CulturedLabels",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 1000, nullable: false),
                    Lcid = table.Column<int>(nullable: false),
                    TranslationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulturedLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CulturedLabels_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalSchema: "dbo",
                        principalTable: "Translations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CulturedLabels_TranslationId",
                schema: "dbo",
                table: "CulturedLabels",
                column: "TranslationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CulturedLabels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Translations",
                schema: "dbo");
        }
    }
}
