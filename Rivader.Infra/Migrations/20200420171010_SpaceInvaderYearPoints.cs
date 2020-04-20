using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class SpaceInvaderYearPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Points",
                schema: "dbo",
                table: "SpaceInvaders",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                schema: "dbo",
                table: "SpaceInvaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                schema: "dbo",
                table: "SpaceInvaders");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "dbo",
                table: "SpaceInvaders");
        }
    }
}
