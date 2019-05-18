FROM microsoft/dotnet:2.2-sdk-alpine AS base

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Caprimulgidae.WebApi.dll