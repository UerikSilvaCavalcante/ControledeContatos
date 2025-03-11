# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/

# restore
COPY ["ControledeContatos/ControledeContatos.csproj", "ControledeContatos/"]            
RUN dotnet restore "ControledeContatos/ControledeContatos.csproj"

# build
COPY ["ControledeContatos/", "ControledeContatos/"]
WORKDIR /src/ControledeContatos
RUN dotnet build "ControledeContatos.csproj" -c Release -o /app/build

# Stage 2: publish
FROM build AS publish
RUN dotnet publish "ControledeContatos.csproj" -c Release -o /app/publish

# Stage 3: Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControledeContatos.dll"]