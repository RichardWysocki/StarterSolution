#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ASPNET_API/ASPNET_API.csproj", "ASPNET_API/"]
RUN dotnet restore "ASPNET_API/ASPNET_API.csproj"
COPY . .
WORKDIR "/src/ASPNET_API"
RUN dotnet build "ASPNET_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASPNET_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASPNET_API.dll"]