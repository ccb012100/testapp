FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY TestApp.WebApp/*.csproj ./TestApp.WebApp/
# Restore as distinct layers
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app/TestApp.WebApp
RUN dotnet publish --configuration debug --no-restore --output /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "TestApp.WebApp.dll"]
