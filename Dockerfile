# Utiliza la imagen base de .NET SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app


# Copia los archivos .csproj y restaura las dependencias
COPY Presentation/AA1.Presentation.csproj ./Presentation/
COPY Models/AA1.Models.csproj ./Models/
RUN dotnet restore Presentation/AA1.Presentation.csproj

# Copia los archivos restantes y construye la aplicación
COPY . ./
RUN dotnet publish Presentation/AA1.Presentation.csproj -c Release -o out

# Genera la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Presentation/AA1.Presentation.dll"]

# Expone el puerto 6107
EXPOSE 6107
