﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TaxCalculator.Api/TaxCalculator.Api.csproj", "TaxCalculator.Api/"]
RUN dotnet restore "TaxCalculator.Api/TaxCalculator.Api.csproj"
COPY . .
WORKDIR "/src/TaxCalculator.Api"
RUN dotnet build "TaxCalculator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxCalculator.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxCalculator.Api.dll"]
