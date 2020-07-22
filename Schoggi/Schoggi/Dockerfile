#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Schoggi/Schoggi.csproj", "Schoggi/"]
RUN dotnet restore "Schoggi/Schoggi.csproj"
COPY . .
WORKDIR "/src/Schoggi"
RUN dotnet build "Schoggi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Schoggi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Schoggi.dll"]