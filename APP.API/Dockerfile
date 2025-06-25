# ------------------ BASE IMAGE ------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5009

# ------------------ BUILD IMAGE ------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy individual project files
COPY ["APP.API/APP.API.csproj", "APP.API/"]
COPY ["APP.BLL/APP.BLL.csproj", "APP.BLL/"]
COPY ["APP.DAL/APP.DAL.csproj", "APP.DAL/"]
#COPY ["APP.Tests/APP.Tests.csproj", "APP.Tests/"]

# Restore dependencies
RUN dotnet restore "APP.API/APP.API.csproj" --disable-parallel

# Copy the full solution files
COPY . .

# Set working directory to the API project
WORKDIR "/src/APP.API"

# Build the application
RUN dotnet build "APP.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ------------------ PUBLISH IMAGE ------------------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/APP.API"
RUN dotnet publish "APP.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# ------------------ FINAL IMAGE ------------------
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APP.API.dll"]