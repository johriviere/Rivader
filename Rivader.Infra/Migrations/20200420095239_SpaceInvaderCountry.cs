using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class SpaceInvaderCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "dbo",
                table: "SpaceInvaders",
                maxLength: 3,
                nullable: false,
                defaultValue: "FRA");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceInvaders_CountryCode",
                schema: "dbo",
                table: "SpaceInvaders",
                column: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceInvaders_Countries_CountryCode",
                schema: "dbo",
                table: "SpaceInvaders",
                column: "CountryCode",
                principalSchema: "dbo",
                principalTable: "Countries",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceInvaders_Countries_CountryCode",
                schema: "dbo",
                table: "SpaceInvaders");

            migrationBuilder.DropIndex(
                name: "IX_SpaceInvaders_CountryCode",
                schema: "dbo",
                table: "SpaceInvaders");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "dbo",
                table: "SpaceInvaders");
        }
    }
}
