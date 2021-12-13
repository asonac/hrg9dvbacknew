#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Integration/Integration.API/Integration.API.csproj", "Services/Integration/Integration.API/"]
COPY ["Services/Integration/Integration.Infrastructure/Integration.Infrastructure.csproj", "Services/Integration/Integration.Infrastructure/"]
COPY ["Services/Integration/Integration.Application/Integration.Application.csproj", "Services/Integration/Integration.Application/"]
COPY ["Services/Integration/Integration.Domain/Integration.Domain.csproj", "Services/Integration/Integration.Domain/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/Integration/Integration.API/Integration.API.csproj"
COPY . .
WORKDIR "/src/Services/Integration/Integration.API"
RUN dotnet build "Integration.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Integration.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Integration.API.dll"]
