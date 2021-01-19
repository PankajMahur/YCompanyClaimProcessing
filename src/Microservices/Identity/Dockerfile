#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservices/Identity/YCompany.Identity.API.csproj", "src/Microservices/Identity/"]
COPY ["src/Microservices/Common/YCompany.Microservices.EntityFrameworkCore/YCompany.Microservices.EntityFrameworkCore.csproj", "src/Microservices/Common/YCompany.Microservices.EntityFrameworkCore/"]
RUN dotnet restore "src/Microservices/Identity/YCompany.Identity.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Identity"
RUN dotnet build "YCompany.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YCompany.Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YCompany.Identity.API.dll"]
