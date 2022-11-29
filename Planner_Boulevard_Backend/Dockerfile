FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /Planner_Boulevard_Backend
COPY published/ ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]