#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ASPNET_WebApplication/ASPNET_WebApplication.csproj", "ASPNET_WebApplication/"]
RUN dotnet restore "ASPNET_WebApplication/ASPNET_WebApplication.csproj"
COPY . .
WORKDIR "/src/ASPNET_WebApplication"
RUN dotnet build "ASPNET_WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASPNET_WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASPNET_WebApplication.dll"]