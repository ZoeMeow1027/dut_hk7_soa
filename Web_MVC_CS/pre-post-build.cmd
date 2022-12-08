dotnet tool install --global dotnet-ef


dotnet-ef migrations add ChangeLog
dotnet-ef database update
