# Use a imagem oficial do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copie os arquivos de projeto e restaure as dependências
COPY *.csproj ./ControledeContatos
RUN dotnet restore

# Copie o restante dos arquivos e compile o projeto
COPY . ./ControledeContatos
RUN dotnet publish -c Release -o out

# Use a imagem oficial do .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exponha a porta e inicie o aplicativo
EXPOSE 80
ENTRYPOINT ["dotnet", "ControledeContatos.dll"]