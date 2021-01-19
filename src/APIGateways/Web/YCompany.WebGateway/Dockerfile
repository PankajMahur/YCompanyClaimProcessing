#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/APIGateways/Web/YCompany.WebGateway/YCompany.WebGateway.csproj", "src/APIGateways/Web/YCompany.WebGateway/"]
COPY ["src/APIGateways/AuthCommon/YCompany.Gateways.AuthCommon/YCompany.Gateways.AuthCommon.csproj", "src/APIGateways/AuthCommon/YCompany.Gateways.AuthCommon/"]
COPY ["src/APIGateways/Web/YCompany.Web.HttpAggregator/YCompany.Web.HttpAggregator.csproj", "src/APIGateways/Web/YCompany.Web.HttpAggregator/"]
COPY ["src/Aggregator.Models/ApiGateways.HttpAggregator.Models/ApiGateways.HttpAggregator.Models.csproj", "src/Aggregator.Models/ApiGateways.HttpAggregator.Models/"]
RUN dotnet restore "src/APIGateways/Web/YCompany.WebGateway/YCompany.WebGateway.csproj"
COPY . .
WORKDIR "/src/src/APIGateways/Web/YCompany.WebGateway"
RUN dotnet build "YCompany.WebGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YCompany.WebGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YCompany.WebGateway.dll"]
