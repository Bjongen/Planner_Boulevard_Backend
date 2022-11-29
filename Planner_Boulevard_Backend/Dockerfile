
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Planner_Boulevard_Backend

# copy csproj and restore as distinct layers
COPY *.sln .
COPY aspnetapp/*.csproj ./aspnetapp/
RUN dotnet restore

# copy everything else and build app
COPY aspnetapp/. ./aspnetapp/
WORKDIR /source/aspnetapp
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /Planner_Boulevard_Backend
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]