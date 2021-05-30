FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HashTable.ConsoleApp/HashTable.ConsoleApp.csproj", "HashTable.ConsoleApp/"]
RUN dotnet restore "HashTable.ConsoleApp/HashTable.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/HashTable.ConsoleApp"
RUN dotnet build "HashTable.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HashTable.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HashTable.ConsoleApp.dll"]
