FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/NetCoreVolunteering.API/NetCoreVolunteering.API.csproj", "src/NetCoreVolunteering.API/"]
COPY ["src/NetCoreVolunteering.Infrastructure/NetCoreVolunteering.Infrastructure.csproj", "src/NetCoreVolunteering.Infrastructure/"]
COPY ["src/NetCoreVolunteering.Application/NetCoreVolunteering.Application.csproj", "src/NetCoreVolunteering.Application/"]
COPY ["src/NetCoreVolunteering.Domain/NetCoreVolunteering.Domain.csproj", "src/NetCoreVolunteering.Domain/"]
RUN dotnet restore "src/NetCoreVolunteering.API/NetCoreVolunteering.API.csproj"
COPY . .
WORKDIR "/src/src/NetCoreVolunteering.API"
RUN dotnet build "NetCoreVolunteering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NetCoreVolunteering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreVolunteering.API.dll"]
