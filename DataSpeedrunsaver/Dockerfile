FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# Keep the original solution file name but update the project path and name
COPY ["DataSpeedrunsaver.csproj", "Speedrunsaver/"]
RUN dotnet restore "Speedrunsaver/DataSpeedrunsaver.csproj"
COPY . .
WORKDIR "/src/Speedrunsaver"
RUN dotnet build "DataSpeedrunsaver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataSpeedrunsaver.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataSpeedrunsaver.dll"]