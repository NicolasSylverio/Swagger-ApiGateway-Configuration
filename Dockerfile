#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Swagger.Gateway.Configuration.csproj", ""]
RUN dotnet restore "./Swagger.Gateway.Configuration.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Swagger.Gateway.Configuration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swagger.Gateway.Configuration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swagger.Gateway.Configuration.dll"]