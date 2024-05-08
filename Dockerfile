FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "./"]

COPY ["src/NursingHome.WebApi/NursingHome.WebApi.csproj", "src/NursingHome.WebApi/"]
COPY ["src/NursingHome.Infrastructure/NursingHome.Infrastructure.csproj", "src/NursingHome.Infrastructure/"]
COPY ["src/NursingHome.Application/NursingHome.Application.csproj", "src/NursingHome.Application/"]
COPY ["src/NursingHome.Domain/NursingHome.Domain.csproj", "src/NursingHome.Domain/"]
COPY ["src/NursingHome.Shared/NursingHome.Shared.csproj", "src/NursingHome.Shared/"]

RUN dotnet restore "./src/NursingHome.WebApi/./NursingHome.WebApi.csproj"
COPY . .
WORKDIR "/src/src/NursingHome.WebApi"
RUN dotnet build "./NursingHome.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NursingHome.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "NursingHome.WebApi.dll"]