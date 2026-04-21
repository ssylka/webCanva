# ЭТАП 1 — билд
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# копируем всё остальное
COPY . ./
RUN dotnet publish -c Release -o out

# ЭТАП 2 — рантайм
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# копируем билд
COPY --from=build /app/out .

# порт
EXPOSE 8080

# запуск
ENTRYPOINT ["dotnet", "DrowingTogether.dll"]