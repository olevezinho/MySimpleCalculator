#7.0.302-bullseye-slim-amd64

# Base
FROM mcr.microsoft.com/dotnet/aspnet:7.0.5-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

# SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0.302-bullseye-slim AS build
WORKDIR /src/MySimpleCalculatorWebAPI/
COPY *.csproj ./
RUN dotnet nuget add source https://nuget.pkg.github.com/olevezinho/index.json -n "github" -u "oLevezinho" -p "" --store-password-in-clear-text
RUN dotnet restore --source https://nuget.pkg.github.com/olevezinho/index.json
COPY . .
WORKDIR /src/MySimpleCalculatorWebAPI/
RUN dotnet build -c Release -o /app

# Publish
FROM build AS publish
RUN dotnet publish -r linux-x64 -c Release /p:PublishTrimmed=true -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","MySimpleCalculatorWebAPI.dll"]