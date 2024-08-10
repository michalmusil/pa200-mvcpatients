# Use the official .NET 8 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining files and build the application
COPY . ./
RUN dotnet publish MvcPatients.generated.sln -c Release -o out

# Use the official .NET 8 runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Set the environment variables for the connection string
ENV DB_HOST=your_host
ENV DB_NAME=patientsdb
ENV DB_USER=your_username
ENV DB_PASSWORD=your_password

# Expose the port
EXPOSE 8080

# Run the application
#ENTRYPOINT ["tail", "-f", "/dev/null"]
ENTRYPOINT ["dotnet", "MvcPatients.dll"]
