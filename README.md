# Testing.Net
Study testing in ASP.NET Core 3

## Commands
### Project
dotnet new globaljson --sdk-version 5.0.302 --output Testing.Net/SimpleApp
dotnet new web --no-https --output Testing.Net/SimpleApp --framework net5.0
dotnet new sln -o Testing.Net
dotnet sln  Testing.Net add Testing.Net/SimpleApp


### Tests Project
dotnet new xunit -o SimpleApp.Tests --framework net5.0
dotnet sln add SimpleApp.Tests
dotnet add SimpleApp.Tests reference SimpleApp



