FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY ./ ./
RUN dotnet publish -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
LABEL build.version="1.0"
WORKDIR /app
COPY --from=build src/publish ./
ENTRYPOINT ["dotnet", "MagicVilla_VillaAPI.dll"]