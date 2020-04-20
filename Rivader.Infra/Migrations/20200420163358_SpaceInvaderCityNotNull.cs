using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class SpaceInvaderCityNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DECLARE @DefaultCityId INT;
                SELECT @DefaultCityId = [Id] FROM [dbo].[Cities] WHERE [Code] = 'PA'

                UPDATE [dbo].[SpaceInvaders]
                SET [CityId] = @DefaultCityId
                WHERE [CityId] IS NULL

            ");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                schema: "dbo",
                table: "SpaceInvaders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                schema: "dbo",
                table: "SpaceInvaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
