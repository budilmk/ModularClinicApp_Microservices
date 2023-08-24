#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Notification.Bootstrapper/Notification.Bootstrapper.csproj", "Notification.Bootstrapper/"]
COPY ["Notification.API/Notification.API.csproj", "Notification.API/"]
COPY ["Notification.Application/Notification.Application.csproj", "Notification.Application/"]
COPY ["SlotManagement/SlotManagement.csproj", "SlotManagement/"]
COPY ["Booking.Application/Booking.Application.csproj", "Booking.Application/"]
COPY ["Booking.Shared/Booking.Shared.csproj", "Booking.Shared/"]
COPY ["Booking.Domain/Booking.Domain.csproj", "Booking.Domain/"]
COPY ["Shared.Core/Shared.Core.csproj", "Shared.Core/"]
COPY ["Booking.Infrastructure/Booking.Infrastructure.csproj", "Booking.Infrastructure/"]
COPY ["Authentication.API/Authentication.API.csproj", "Authentication.API/"]
RUN dotnet restore "Notification.Bootstrapper/Notification.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/Notification.Bootstrapper"
RUN dotnet build "Notification.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notification.Bootstrapper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.Bootstrapper.dll"]