#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FastFoodFIAP.Services.Api/FastFoodFIAP.Services.Api.csproj", "src/FastFoodFIAP.Services.Api/"]
COPY ["src/GenericPack/GenericPack.csproj", "src/GenericPack/"]
COPY ["src/FastFoodFIAP.Application/FastFoodFIAP.Application.csproj", "src/FastFoodFIAP.Application/"]
COPY ["src/FastFoodFIAP.Domain/FastFoodFIAP.Domain.csproj", "src/FastFoodFIAP.Domain/"]
COPY ["src/FastFoodFIAP.Infra.Data/FastFoodFIAP.Infra.Data.csproj", "src/FastFoodFIAP.Infra.Data/"]
COPY ["src/FastFoodFIAP.Infra.CrossCutting.IoC/FastFoodFIAP.Infra.CrossCutting.IoC.csproj", "src/FastFoodFIAP.Infra.CrossCutting.IoC/"]
RUN dotnet restore "src/FastFoodFIAP.Services.Api/FastFoodFIAP.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/FastFoodFIAP.Services.Api"
RUN dotnet build "FastFoodFIAP.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FastFoodFIAP.Services.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastFoodFIAP.Services.Api.dll"]
