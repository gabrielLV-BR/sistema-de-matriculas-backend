FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App
EXPOSE 80
EXPOSE 443

# Copia arquivos pro container
COPY . /App

# Inicia e instala pacotes
RUN dotnet restore

ENTRYPOINT ['dotnet', 'run']