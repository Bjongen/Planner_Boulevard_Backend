FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish Planner_Boulevard_Backend.sln -c Release -o out
WORKDIR /app/out
ENTRYPOINT ["dotnet" ,"/app/out/Planner_Boulevard_Backend.dll"]