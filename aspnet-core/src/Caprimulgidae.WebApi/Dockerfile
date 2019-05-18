FROM microsoft/dotnet:2.2-sdk-alpine AS base

WORKDIR /app

COPY . .

ENTRYPOINT ["dotnet", "Caprimulgidae.WebApi.dll"]