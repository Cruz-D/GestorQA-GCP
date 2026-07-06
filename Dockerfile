FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/GestorQA-GCP.Api/GestorQA-GCP.Api.csproj", "src/GestorQA-GCP.Api/"]
COPY ["src/GestorQA-GCP.Application/GestorQA-GCP.Application.csproj", "src/GestorQA-GCP.Application/"]
COPY ["src/GestorQA-GCP.Domain/GestorQA-GCP.Domain.csproj", "src/GestorQA-GCP.Domain/"]
COPY ["src/GestorQA-GCP.Infrastructure/GestorQA-GCP.Infrastructure.csproj", "src/GestorQA-GCP.Infrastructure/"]
RUN dotnet restore "src/GestorQA-GCP.Api/GestorQA-GCP.Api.csproj"

COPY . .
WORKDIR /src/src/GestorQA-GCP.Api
RUN dotnet publish "GestorQA-GCP.Api.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GestorQA-GCP.Api.dll"]