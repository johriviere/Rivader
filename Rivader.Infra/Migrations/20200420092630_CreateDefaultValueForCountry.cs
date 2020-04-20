using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class CreateDefaultValueForCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DECLARE @TranslationId INT;

                BEGIN
                    IF NOT EXISTS(SELECT 1 FROM [dbo].[CulturedLabels] WHERE [Lcid] = 1036 AND [Value] = 'France')
	                    BEGIN
		                    INSERT INTO [dbo].[Translations] DEFAULT VALUES
		                    SET @TranslationId = SCOPE_IDENTITY();
		                    INSERT INTO [dbo].[CulturedLabels] ([Lcid], [Value], [TranslationId]) VALUES (1036, 'France', @TranslationId)
	                    END
                    ELSE
	                    SELECT TOP 1 @TranslationId = [TranslationId] FROM [dbo].[CulturedLabels] WHERE [Lcid] = 1036 AND [Value] = 'France'
                END

                -- https://www.adminlost.com/2016/05/sql-eviter-les-doublons-insert-if-not-exists/
                INSERT INTO [dbo].[Countries] ([Code], [TranslationId])
                SELECT 'FRA', @TranslationId
                WHERE NOT EXISTS (SELECT Code FROM [dbo].[Countries] WHERE [Code] = 'FRA')

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
