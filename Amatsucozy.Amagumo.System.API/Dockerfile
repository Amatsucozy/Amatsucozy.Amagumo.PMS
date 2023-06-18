FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Amatsucozy.Amagumo.System.API/Amatsucozy.Amagumo.System.API.csproj", "Amatsucozy.Amagumo.System.API/"]
RUN dotnet restore "Amatsucozy.Amagumo.System.API/Amatsucozy.Amagumo.System.API.csproj"
COPY . .
WORKDIR "/src/Amatsucozy.Amagumo.System.API"
RUN dotnet build "Amatsucozy.Amagumo.System.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Amatsucozy.Amagumo.System.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Amatsucozy.Amagumo.System.API.dll"]
