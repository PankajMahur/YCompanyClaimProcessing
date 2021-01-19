#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservices/Claim/YCompany.Claim.API.csproj", "src/Microservices/Claim/"]
COPY ["src/EventBus/YCompany.Microservice.RabbitMQ.Infra.IOC/YCompany.Library.RabbitMQ.Infra.IOC.csproj", "src/EventBus/YCompany.Microservice.RabbitMQ.Infra.IOC/"]
COPY ["src/EventBus/YCompany.Microservice.RabbitMq.Infra.Bus/YCompany.Library.RabbitMQ.Infra.Bus.csproj", "src/EventBus/YCompany.Microservice.RabbitMq.Infra.Bus/"]
COPY ["src/EventBus/YCompany.MicroRabbit.Domain.Core/YCompany.Library.MicroRabbit.Core.csproj", "src/EventBus/YCompany.MicroRabbit.Domain.Core/"]
COPY ["src/Microservices/Common/YCompany.Microservices.EntityFrameworkCore/YCompany.Microservices.EntityFrameworkCore.csproj", "src/Microservices/Common/YCompany.Microservices.EntityFrameworkCore/"]
COPY ["src/Microservices/Common/YCompany.Microservices.Enums/YCompany.Microservices.Enums.csproj", "src/Microservices/Common/YCompany.Microservices.Enums/"]
COPY ["src/Microservices/Common/YCompany.Microservices.Claim.EventSourcing/YCompany.Microservices.EventSourcing.csproj", "src/Microservices/Common/YCompany.Microservices.Claim.EventSourcing/"]
RUN dotnet restore "src/Microservices/Claim/YCompany.Claim.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Claim"
RUN dotnet build "YCompany.Claim.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YCompany.Claim.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YCompany.Claim.API.dll"]
