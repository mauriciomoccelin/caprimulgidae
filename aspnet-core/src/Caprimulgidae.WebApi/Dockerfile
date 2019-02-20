FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Caprimulgidae.WebApi/Caprimulgidae.WebApi.csproj", "src/Caprimulgidae.WebApi/"]
COPY ["src/Caprimulgidae.Application/Caprimulgidae.Application.csproj", "src/Caprimulgidae.Application/"]
COPY ["src/Caprimulgidae.Domain/Caprimulgidae.Domain.csproj", "src/Caprimulgidae.Domain/"]
COPY ["src/Caprimulgidae.Infra.CrossCutting.IoC/Caprimulgidae.Infra.CrossCutting.IoC.csproj", "src/Caprimulgidae.Infra.CrossCutting.IoC/"]
COPY ["src/Caprimulgidae.Infra.Data/Caprimulgidae.Infra.Data.csproj", "src/Caprimulgidae.Infra.Data/"]
COPY ["src/Caprimulgidae.Infra.CrossCutting.Bus/Caprimulgidae.Infra.CrossCutting.Bus.csproj", "src/Caprimulgidae.Infra.CrossCutting.Bus/"]
RUN dotnet restore "src/Caprimulgidae.WebApi/Caprimulgidae.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Caprimulgidae.WebApi"
RUN dotnet build "Caprimulgidae.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Caprimulgidae.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Caprimulgidae.WebApi.dll"]