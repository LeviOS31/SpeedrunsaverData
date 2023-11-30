FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Keep the original solution file name but update the project path and name
COPY . .
RUN dotnet restore "DataSpeedrunsaver/DataSpeedrunsaver.csproj"

RUN dotnet publish "DataSpeedrunsaver/DataSpeedrunsaver.csproj" -c Release -o out

from mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5099

ENTRYPOINT ["dotnet", "DataSpeedrunsaver.dll"]
