#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApiGateway/OnlineAuction.ApiGateway/OnlineAuction.ApiGateway.csproj", "ApiGateway/OnlineAuction.ApiGateway/"]
RUN dotnet restore "ApiGateway/OnlineAuction.ApiGateway/OnlineAuction.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateway/OnlineAuction.ApiGateway"
RUN dotnet build "OnlineAuction.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineAuction.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineAuction.ApiGateway.dll"]
