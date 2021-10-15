#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OfiCondo.Management.Api/OfiCondo.Management.Api.csproj", "OfiCondo.Management.Api/"]
COPY ["OfiCondo.Management.Infrastructure/OfiCondo.Management.Infrastructure.csproj", "OfiCondo.Management.Infrastructure/"]
COPY ["OfiCondo.Management.Application/OfiCondo.Management.Application.csproj", "OfiCondo.Management.Application/"]
COPY ["OfiCondo.Management.Domain/OfiCondo.Management.Domain.csproj", "OfiCondo.Management.Domain/"]
COPY ["OfiCondo.Management.Persistence/OfiCondo.Management.Persistence.csproj", "OfiCondo.Management.Persistence/"]
COPY ["OfiCondo.Management.Identity/OfiCondo.Management.Identity.csproj", "OfiCondo.Management.Identity/"]
RUN dotnet restore "OfiCondo.Management.Api/OfiCondo.Management.Api.csproj"
COPY . .
WORKDIR "/src/OfiCondo.Management.Api"
RUN dotnet build "OfiCondo.Management.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OfiCondo.Management.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OfiCondo.Management.Api.dll"]