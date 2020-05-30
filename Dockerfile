FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./projetotg
RUN cd projetotg && dotnet restore

# copy everything else and build app
COPY . ./projetotg
WORKDIR /app/projetotg
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/projetotg/out ./
ENTRYPOINT ["dotnet", "projetotg.dll"]