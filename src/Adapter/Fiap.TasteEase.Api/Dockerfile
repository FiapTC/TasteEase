#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Fiap.TasteEase.Api/Fiap.TasteEase.Api.csproj", "Fiap.TasteEase.Api/"]
RUN dotnet restore "Fiap.TasteEase.Api/Fiap.TasteEase.Api.csproj"
COPY . .
WORKDIR "/src/Fiap.TasteEase.Api"
RUN dotnet build "Fiap.TasteEase.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.TasteEase.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.TasteEase.Api.dll"]