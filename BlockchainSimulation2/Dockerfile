FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BlockchainSimulation2/BlockchainSimulation2.csproj", "BlockchainSimulation2/"]
RUN dotnet restore "BlockchainSimulation2/BlockchainSimulation2.csproj"
COPY . .
WORKDIR "/src/BlockchainSimulation2"
RUN dotnet build "BlockchainSimulation2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlockchainSimulation2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlockchainSimulation2.dll"]