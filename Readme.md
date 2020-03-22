EF CORE MIGRATIONS
------------------

ADD MIGRATION

cd C:\sources\draft\Rivader
dotnet ef migrations add InitialCreate --project Rivader.Infra\Rivader.Infra.csproj --startup-project Rivader.Web\Rivader.Web.csproj

REMOVE MIGRATION
cd C:\sources\draft\Rivader
dotnet ef migrations remove --project Rivader.Infra\Rivader.Infra.csproj --startup-project Rivader.Web\Rivader.Web.csproj

APPLY MIGRATION
dotnet ef database update --project Rivader.Infra\Rivader.Infra.csproj --startup-project Rivader.Web\Rivader.Web.csproj