FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . .

RUN dotnet restore "./TestMaker.Evaluation.API/TestMaker.Evaluation.API.csproj"
RUN dotnet publish "./TestMaker.Evaluation.API/TestMaker.Evaluation.API.csproj" -c Release -o /app/out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out ./

ENTRYPOINT ["dotnet", "TestMaker.Evaluation.API.dll"]