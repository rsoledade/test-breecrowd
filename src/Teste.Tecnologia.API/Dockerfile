# Use o SDK do .NET Core para a construção da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Usando SDK do .NET Core para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Teste.Tecnologia.API/Teste.Tecnologia.API.csproj", "src/Teste.Tecnologia.API/"]
RUN dotnet restore "./src/Teste.Tecnologia.API/Teste.Tecnologia.API.csproj"
COPY . .
WORKDIR "/src/src/Teste.Tecnologia.API"
RUN dotnet build "Teste.Tecnologia.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teste.Tecnologia.API.csproj" -c Release -o /app/publish

# Copiar a aplicação para o contêiner
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste.Tecnologia.API.dll"]
