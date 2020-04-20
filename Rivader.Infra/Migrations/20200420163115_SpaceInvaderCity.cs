using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class SpaceInvaderCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                schema: "dbo",
                table: "SpaceInvaders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpaceInvaders_CityId",
                schema: "dbo",
                table: "SpaceInvaders",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceInvaders_Cities_CityId",
                schema: "dbo",
                table: "SpaceInvaders",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceInvaders_Cities_CityId",
                schema: "dbo",
                table: "SpaceInvaders");

            migrationBuilder.DropIndex(
                name: "IX_SpaceInvaders_CityId",
                schema: "dbo",
                table: "SpaceInvaders");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "dbo",
                table: "SpaceInvaders");
        }
    }
}
