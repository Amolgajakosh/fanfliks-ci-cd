# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ../Fanfliks.API/Fanfliks.API.csproj .
RUN dotnet restore ./Fanfliks.API.csproj

COPY ../Fanfliks.API/. .
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Fanfliks.API.dll"]
