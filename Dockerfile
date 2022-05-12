FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine-arm64v8 AS build
WORKDIR /app
COPY . .
RUN dotnet publish Cloud.Andrii.Shpak -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine-arm64v8
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS http://*:80
ENTRYPOINT dotnet Cloud.Andrii.Shpak.dll