FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . .

RUN dotnet restore "./TestMaker.Authentication.API/TestMaker.Authentication.API.csproj"
RUN dotnet publish "./TestMaker.Authentication.API/TestMaker.Authentication.API.csproj" -c Release -o /app/out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "TestMaker.Authentication.API.dll"]