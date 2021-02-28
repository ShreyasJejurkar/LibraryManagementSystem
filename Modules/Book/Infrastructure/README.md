## Migrations command
1. Install `dotnet-ef` global tool with following command.
   `dotnet tool install --global dotnet-ef`
1. dotnet ef migrations add "first" --startup-project ../Service
2. dotnet ef database update --startup-project ../Service