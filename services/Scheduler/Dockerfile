FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "Scheduler.sln"

WORKDIR /src/Scheduler.API
RUN dotnet publish --no-restore -c Release -o /app

# FROM build as unittest
# WORKDIR /src/Services/Basket/Basket.UnitTests

# FROM build as functionaltest
# WORKDIR /src/Services/Basket/Basket.FunctionalTests

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Scheduler.API.dll"]