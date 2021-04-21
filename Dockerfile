FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
# /app is created if it doesn't exist
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY . ./
RUN dotnet restore

COPY . ./
RUN dotnet publish WebApp.Api -c Debug -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApp.Api.dll"]
