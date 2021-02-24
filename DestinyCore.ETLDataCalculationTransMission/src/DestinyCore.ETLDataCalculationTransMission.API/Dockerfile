#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/DestinyCore.ETLDataCalculationTransMission.API/DestinyCore.ETLDataCalculationTransMission.API.csproj", "src/DestinyCore.ETLDataCalculationTransMission.API/"]
RUN dotnet restore "src/DestinyCore.ETLDataCalculationTransMission.API/DestinyCore.ETLDataCalculationTransMission.API.csproj"
COPY . .
WORKDIR "/src/src/DestinyCore.ETLDataCalculationTransMission.API"
RUN dotnet build "DestinyCore.ETLDataCalculationTransMission.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DestinyCore.ETLDataCalculationTransMission.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DestinyCore.ETLDataCalculationTransMission.API.dll"]