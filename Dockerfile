FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["IAgro.Api/IAgro.Api.csproj", "IAgro.Api/"]
COPY ["IAgro.Persistence/IAgro.Persistence.csproj", "IAgro.Persistence/"]
COPY ["IAgro.Application/IAgro.Application.csproj", "IAgro.Application/"]
COPY ["IAgro.Domain/IAgro.Domain.csproj", "IAgro.Domain/"]
RUN dotnet restore "IAgro.Api/IAgro.Api.csproj"

COPY . .
WORKDIR "/src/IAgro.Api"
RUN dotnet build "IAgro.Api.csproj" -c Debug -o /app/build

RUN dotnet tool install --global dotnet-ef \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && dotnet ef database update --project ../IAgro.Persistence --startup-project . --no-build

FROM build AS publish

RUN dotnet publish "IAgro.Api.csproj" -c Debug -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IAgro.Api.dll"]