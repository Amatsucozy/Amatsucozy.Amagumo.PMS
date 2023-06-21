FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Amatsucozy.Amagumo.Users.API/Amatsucozy.Amagumo.Users.API.csproj", "Amatsucozy.Amagumo.Users.API/"]
RUN dotnet restore "Amatsucozy.Amagumo.Users.API/Amatsucozy.Amagumo.Users.API.csproj"
COPY . .
WORKDIR "/src/Amatsucozy.Amagumo.Users.API"
RUN dotnet build "Amatsucozy.Amagumo.Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Amatsucozy.Amagumo.Users.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Amatsucozy.Amagumo.Users.API.dll"]
