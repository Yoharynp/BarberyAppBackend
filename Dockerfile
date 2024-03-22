FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build.env

WORKDIR /app

Expose 5000

# Copiar solo el archivo de proyecto principal
COPY ./BarberyApp/*.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos de proyecto
COPY ./BappDominio/*.csproj ./BappDominio/
COPY ./BappInfraestructura/*.csproj ./BappInfraestructura/
COPY ./BarberyApp.Dominio/*.csproj ./BarberyApp.Dominio/
COPY ./BarberyApp.Infraestructura/*.csproj ./BarberyApp.Infraestructura/

# Restaurar los demás proyectos
RUN dotnet restore

# Copiar el resto del código fuente
COPY . ./

# Publicar la solución
RUN dotnet publish -c Release -o out

# Configurar la imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime-env
WORKDIR /app
COPY --from=build.env /app/out .


ENTRYPOINT ["dotnet", "BarberyApp.dll"]
