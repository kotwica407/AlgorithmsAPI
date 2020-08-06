FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AlgorithmsAPI.Web/AlgorithmsAPI.Web.csproj", "AlgorithmsAPI.Web/"]
RUN dotnet restore "AlgorithmsAPI.Web/AlgorithmsAPI.Web.csproj" \
-s "https://www.nuget.org/api/v2/"
COPY . .
WORKDIR "/src/AlgorithmsAPI.Web"
RUN dotnet build "AlgorithmsAPI.Web.csproj" -c Release -o /app/build \
--source "https://www.nuget.org/api/v2/"

FROM build AS publish
RUN dotnet publish "AlgorithmsAPI.Web.csproj" -c Release -o /app/publish \
--source "https://www.nuget.org/api/v2/"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlgorithmsAPI.Web.dll"]
