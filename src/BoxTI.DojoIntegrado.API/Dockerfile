#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BoxTI.DojoIntegrado.API/BoxTI.DojoIntegrado.API.csproj", "src/BoxTI.DojoIntegrado.API/"]
COPY ["src/BoxTI.DojoIntegrado.Infrastructure/BoxTI.DojoIntegrado.Infrastructure.csproj", "src/BoxTI.DojoIntegrado.Infrastructure/"]
COPY ["src/BoxTI.DojoIntegrado.Domain/BoxTI.DojoIntegrado.Domain.csproj", "src/BoxTI.DojoIntegrado.Domain/"]
COPY ["src/BoxTI.DojoIntegrado.Services/BoxTI.DojoIntegrado.Services.csproj", "src/BoxTI.DojoIntegrado.Services/"]
RUN dotnet restore "src/BoxTI.DojoIntegrado.API/BoxTI.DojoIntegrado.API.csproj"
COPY . .
WORKDIR "/src/src/BoxTI.DojoIntegrado.API"
RUN dotnet build "BoxTI.DojoIntegrado.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BoxTI.DojoIntegrado.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BoxTI.DojoIntegrado.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BoxTI.DojoIntegrado.API.dll