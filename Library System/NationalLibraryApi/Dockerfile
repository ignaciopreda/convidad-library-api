
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NationalLibraryApi/NationalLibraryApi.csproj", "NationalLibraryApi/"]
RUN dotnet restore "NationalLibraryApi/NationalLibraryApi.csproj"
COPY . .
WORKDIR "/src/NationalLibraryApi"
RUN dotnet build "NationalLibraryApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NationalLibraryApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NationalLibraryApi.dll"]