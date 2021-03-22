#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Continental.Producao.API/Continental.Producao.API.csproj", "Continental.Producao.API/"]
COPY ["Continental.Producao.Infra.Data/Continental.Producao.Infra.Data.csproj", "Continental.Producao.Infra.Data/"]
COPY ["Continental.Producao.Domain/Continental.Producao.Domain.csproj", "Continental.Producao.Domain/"]
COPY ["Continental.Producao.Application/Continental.Producao.Application.csproj", "Continental.Producao.Application/"]
RUN dotnet restore "Continental.Producao.API/Continental.Producao.API.csproj"
COPY . .
WORKDIR "/src/Continental.Producao.API"
RUN dotnet build "Continental.Producao.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Continental.Producao.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Continental.Producao.API.dll"]