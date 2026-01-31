FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY BuberDinner.sln ./
COPY BuberDinner.API/BuberDinner.API.csproj BuberDinner.API/
COPY BuberDinner.Application/BuberDinner.Application.csproj BuberDinner.Application/
COPY BuberDinner.Contracts/BuberDinner.Contracts.csproj BuberDinner.Contracts/
COPY BuberDinner.Domain/BuberDinner.Domain.csproj BuberDinner.Domain/
COPY BuberDinner.Infrastructure/BuberDinner.Infrastructure.csproj BuberDinner.Infrastructure/

RUN dotnet restore BuberDinner.API/BuberDinner.API.csproj

COPY . .
WORKDIR /src/BuberDinner.API
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BuberDinner.API.dll"]
