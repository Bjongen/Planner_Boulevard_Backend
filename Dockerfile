FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Planner_Boulevard_Backend/Planner_Boulevard_Backend.csproj", "Planner_Boulevard_Backend/"]
RUN dotnet restore "Planner_Boulevard_Backend/Planner_Boulevard_Backend.csproj"
COPY . .
WORKDIR "/src/Planner_Boulevard_Backend"
RUN dotnet build "Planner_Boulevard_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Planner_Boulevard_Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planner_Boulevard_Backend.dll"]
