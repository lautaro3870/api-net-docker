# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./CloudCustomers.API/CloudCustomers.API.csproj" --disable-parallel
RUN dotnet publish "./CloudCustomers.API/CloudCustomers.API.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "CloudCustomers.API.dll"]