FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuickBuck/QuickBuck.csproj", "QuickBuck/"]
COPY ["QuickBuck.Repository/QuickBuck.Repository.csproj", "QuickBuck.Repository/"]
COPY ["QuickBuck.Core/QuickBuck.Core.csproj", "QuickBuck.Core/"]
COPY ["QuickBuck.Service/QuickBuck.Service.csproj", "QuickBuck.Service/"]
RUN dotnet restore "./QuickBuck/QuickBuck.csproj"
COPY . .
WORKDIR "/src/QuickBuck"
RUN dotnet publish "./QuickBuck.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080} exec dotnet QuickBuck.dll"]
