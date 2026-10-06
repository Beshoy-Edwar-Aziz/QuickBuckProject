# Explicitly define the base images using ARGs to prevent registry parsing errors
ARG SDK_IMAGE=://microsoft.com
ARG RUNTIME_IMAGE=://microsoft.com

# 1. Build Stage
FROM ${SDK_IMAGE} AS build
WORKDIR /src

# Copy the solution file and all .csproj files to restore dependencies
COPY QuickBuckSolution.sln ./
COPY QuickBuck/*.csproj ./QuickBuck/
COPY QuickBuck.Core/*.csproj ./QuickBuck.Core/
COPY QuickBuck.Repository/*.csproj ./QuickBuck.Repository/
COPY QuickBuck.Service/*.csproj ./QuickBuck.Service/

# Restore dependencies for the entire solution
RUN dotnet restore QuickBuckSolution.sln

# Copy the remaining source code
COPY . .

# Build and publish the main Web API project
WORKDIR "/src/QuickBuck"
RUN dotnet publish -c Release -o /app/out

# 2. Runtime Stage
FROM ${RUNTIME_IMAGE}
WORKDIR /app
COPY --from=build /app/out ./

# Inform Railway of the port (.NET 6 defaults to port 80)
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Run the API
ENTRYPOINT ["dotnet", "QuickBuck.dll"]

ENV ASPNETCORE_URLS=http://+:80

# Run the API (Assuming 'QuickBuck.dll' is your main API output)
ENTRYPOINT ["dotnet", "QuickBuck.dll"]
