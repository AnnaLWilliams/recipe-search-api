FROM postgres:17.6 AS postgres

WORKDIR /var/lib/postgresql/data
EXPOSE 5332

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5198

ENV ASPNETCORE_URLS=http://+:5198

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["recipe-search-api/recipe-search-api.csproj", "recipe-search-api/"]
RUN dotnet restore "recipe-search-api/recipe-search-api.csproj"
COPY . .
WORKDIR "/src/recipe-search-api"
RUN dotnet build "recipe-search-api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "recipe-search-api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "recipe-search-api.dll"]
