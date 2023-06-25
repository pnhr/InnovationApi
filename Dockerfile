FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Innovation.Api/Innovation.Api.csproj", "Innovation.Api/"]
RUN dotnet restore "Innovation.Api/Innovation.Api.csproj"
COPY . .
WORKDIR "/src/Innovation.Api"
RUN dotnet build "Innovation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Innovation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Innovation.Api.dll"]
