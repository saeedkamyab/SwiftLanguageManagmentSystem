# ==========================
# Build Stage
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["Api/SLMS.Api/SLMS.Api.csproj", "Api/SLMS.Api/"]
COPY ["Application/SLMS.Application/SLMS.Application.csproj", "Application/SLMS.Application/"]
COPY ["ApplicationCore/SLMS.ApplicationCore/SLMS.ApplicationCore.csproj", "ApplicationCore/SLMS.ApplicationCore/"]
COPY ["Dto/SLMS.Dto/SLMS.Dto.csproj", "Dto/SLMS.Dto/"]
COPY ["Infrastructure/SLMS.Infrastructure/SLMS.Infrastructure.csproj", "Infrastructure/SLMS.Infrastructure/"]
COPY ["Persistence/SLMS.Persistence/SLMS.Persistence.csproj", "Persistence/SLMS.Persistence/"]
COPY ["Shared/SLMS.Shared/SLMS.Shared.csproj", "Shared/SLMS.Shared/"]

RUN dotnet restore "Api/SLMS.Api/SLMS.Api.csproj"

COPY . .

WORKDIR "/src/Api"

# Publish
RUN dotnet publish "SLMS.Api/SLMS.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# ==========================
# Runtime Stage
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet","SLMS.Api.dll"]
