using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 3, nullable: false, defaultValue: "PA"),
                    TranslationId = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: false, defaultValue: "FRA")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Cities_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalSchema: "dbo",
                        principalTable: "Translations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Code",
                schema: "dbo",
                table: "Cities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCode",
                schema: "dbo",
                table: "Cities",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TranslationId",
                schema: "dbo",
                table: "Cities",
                column: "TranslationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities",
                schema: "dbo");
        }
    }
}
