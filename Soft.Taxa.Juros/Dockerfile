FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80:8081

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Soft.Taxa.Juros.Api/Soft.Taxa.Juros.Api.csproj", "Soft.Taxa.Juros.Api/"]
RUN dotnet restore "Soft.Taxa.Juros.Api/Soft.Taxa.Juros.Api.csproj"
COPY . .
WORKDIR "/src/Soft.Taxa.Juros.Api"
RUN dotnet build "Soft.Taxa.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Soft.Taxa.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Soft.Taxa.Juros.Api.dll"]