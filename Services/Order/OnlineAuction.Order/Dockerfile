#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Order/OnlineAuction.Order/OnlineAuction.Order.csproj", "Services/Order/OnlineAuction.Order/"]
COPY ["Services/Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "Services/Common/EventBusRabbitMQ/"]
COPY ["Services/Order/OnlineAuctionApplication/OnlineAuctionApplication.csproj", "Services/Order/OnlineAuctionApplication/"]
COPY ["Services/Order/OnlineAuction.Domain/OnlineAuction.Domain.csproj", "Services/Order/OnlineAuction.Domain/"]
COPY ["Services/Order/OnlineAuction.Infrastructure/OnlineAuction.Infrastructure.csproj", "Services/Order/OnlineAuction.Infrastructure/"]
RUN dotnet restore "Services/Order/OnlineAuction.Order/OnlineAuction.Order.csproj"
COPY . .
WORKDIR "/src/Services/Order/OnlineAuction.Order"
RUN dotnet build "OnlineAuction.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineAuction.Order.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineAuction.Order.dll"]
