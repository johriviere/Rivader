using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class SpaceInvaderCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                schema: "dbo",
                table: "SpaceInvaders",
                type: "decimal(8,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                schema: "dbo",
                table: "SpaceInvaders",
                type: "decimal(8,5)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "dbo",
                table: "SpaceInvaders");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "dbo",
                table: "SpaceInvaders");
        }
    }
}
