FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80:8082

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Soft.Calculo.Juros.Api/Soft.Calculo.Juros.Api.csproj", "Soft.Calculo.Juros.Api/"]
RUN dotnet restore "Soft.Calculo.Juros.Api/Soft.Calculo.Juros.Api.csproj"
COPY . .
WORKDIR "/src/Soft.Calculo.Juros.Api"
RUN dotnet build "Soft.Calculo.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Soft.Calculo.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Soft.Calculo.Juros.Api.dll"]