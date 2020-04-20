using Microsoft.EntityFrameworkCore.Migrations;

namespace Rivader.Infra.Migrations
{
    public partial class CreateDefaultValueForCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DECLARE @TranslationId INT;

                BEGIN
                    IF NOT EXISTS(SELECT 1 FROM [dbo].[CulturedLabels] WHERE [Lcid] = 1036 AND [Value] = 'Paris')
	                    BEGIN
		                    INSERT INTO [dbo].[Translations] DEFAULT VALUES
		                    SET @TranslationId = SCOPE_IDENTITY();
		                    INSERT INTO [dbo].[CulturedLabels] ([Lcid], [Value], [TranslationId]) VALUES (1036, 'Paris', @TranslationId)
	                    END
                    ELSE
	                    SELECT TOP 1 @TranslationId = [TranslationId] FROM [dbo].[CulturedLabels] WHERE [Lcid] = 1036 AND [Value] = 'Paris'
                END

                INSERT INTO [dbo].[Cities] ([Code], [TranslationId], [CountryCode])
                SELECT 'PA', @TranslationId, 'FRA'
                WHERE NOT EXISTS (SELECT Code FROM [dbo].[Cities] WHERE [Code] = 'PA')

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
