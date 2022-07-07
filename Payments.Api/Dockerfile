FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:5002

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Payments.Api/Payments.Api.csproj", "Payments.Api/"]
RUN dotnet restore "Payments.Api/Payments.Api.csproj"
COPY . .
WORKDIR "/src/Payments.Api"
RUN dotnet build "Payments.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payments.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payments.Api.dll"]
