# https://hub.docker.com/_/microsoft-dotnet

FROM mcr.microsoft.com/dotnet/sdk:5.0.404 AS builder

WORKDIR /build

COPY *.csproj .

RUN dotnet restore

COPY . .

RUN dotnet build -o bin

### CONTAINER ###

FROM mcr.microsoft.com/dotnet/runtime:5.0

WORKDIR /app

COPY --from=builder /build/bin .

ENTRYPOINT ["dotnet", "/app/DotNetDocker.dll"]
