FROM microsoft/dotnet:2.2-sdk-alpine AS build-env

# copy
WORKDIR /
COPY ["/src/Caprimulgidae.WebApi/Caprimulgidae.WebApi.csproj", "src/Caprimulgidae.WebApi/"]
COPY ["/src/Caprimulgidae.Application/Caprimulgidae.Application.csproj", "src/Caprimulgidae.Application/"]
COPY ["/src/Caprimulgidae.Domain/Caprimulgidae.Domain.csproj", "src/Caprimulgidae.Domain/"]
COPY ["/src/Caprimulgidae.Infra.CrossCutting.IoC/Caprimulgidae.Infra.CrossCutting.IoC.csproj", "src/Caprimulgidae.Infra.CrossCutting.IoC/"]
COPY ["/src/Caprimulgidae.Infra.Data/Caprimulgidae.Infra.Data.csproj", "src/Caprimulgidae.Infra.Data/"]
COPY ["/src/Caprimulgidae.Infra.CrossCutting.Bus/Caprimulgidae.Infra.CrossCutting.Bus.csproj", "src/Caprimulgidae.Infra.CrossCutting.Bus/"]
COPY ["/test/Caprimulgidae.Infra.Data.Test/Caprimulgidae.Infra.Data.Test.csproj", "test/Caprimulgidae.Infra.Data.Test/"]

COPY ["Caprimulgidae.sln", "/"]
COPY ["NuGet.Config", "/"]

# restore
RUN dotnet restore --configfile "NuGet.Config"

# test
RUN dotnet test ./test/Caprimulgidae.Infra.Data.Test/Caprimulgidae.Infra.Data.Test.csproj

# build
COPY . .
WORKDIR /src/Caprimulgidae.WebApi
RUN dotnet publish "Caprimulgidae.WebApi.csproj" --configuration Release --output /out --verbosity quiet

# image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "Caprimulgidae.WebApi.dll"]