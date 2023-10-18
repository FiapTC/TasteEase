#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Adapter/Fiap.TasteEase.Api/Fiap.TasteEase.Api.csproj", "src/Adapter/Fiap.TasteEase.Api/"]
COPY ["src/Adapter/Fiap.TasteEase.Infra/Fiap.TasteEase.Infra.csproj", "src/Adapter/Fiap.TasteEase.Infra/"]
COPY ["src/Core/Fiap.TasteEase.Application/Fiap.TasteEase.Application.csproj", "src/Core/Fiap.TasteEase.Application/"]
COPY ["src/Core/Fiap.TasteEase.Domain/Fiap.TasteEase.Domain.csproj", "src/Core/Fiap.TasteEase.Domain/"]

RUN dotnet restore "src/Adapter/Fiap.TasteEase.Api/Fiap.TasteEase.Api.csproj"
COPY . .
WORKDIR "/src/src/Adapter/Fiap.TasteEase.Api"
RUN dotnet build "Fiap.TasteEase.Api.csproj" -c Release --no-restore -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.TasteEase.Api.csproj" -c Release --no-restore -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.TasteEase.Api.dll"]