# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files for caching layer
COPY Service.Catalogos.Domain/Service.Catalogos.Domain.csproj Service.Catalogos.Domain/
COPY Service.Catalogos.Application/Service.Catalogos.Application.csproj Service.Catalogos.Application/
COPY Service.Catalogos.Infrastructure/Service.Catalogos.Infrastructure.csproj Service.Catalogos.Infrastructure/
COPY Service.Catalogos.API/Service.Catalogos.API.csproj Service.Catalogos.API/

# Restore dependencies
RUN dotnet restore Service.Catalogos.API/Service.Catalogos.API.csproj

# Copy all source files
COPY . .

# Build and publish release
WORKDIR /src/Service.Catalogos.API
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Cloud Run defaults
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Service.Catalogos.API.dll"]
