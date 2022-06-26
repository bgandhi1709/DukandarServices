FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DukandarDb/DukandarDb.csproj", "DukandarDb/"]
RUN dotnet restore "DukandarDb/DukandarDb.csproj"
COPY . .
WORKDIR "/src/DukandarDb"
RUN dotnet build "DukandarDb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DukandarDb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DukandarDb.dll"]
