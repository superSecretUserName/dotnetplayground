# Use the official .NET SDK image for development.
FROM mcr.microsoft.com/dotnet/sdk:9.0

# Set the working directory in the container
WORKDIR /app

# Copy the project file and restore dependencies first (for caching)
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . ./

# Expose port 80 (the app will listen on this port)
EXPOSE 80

# Start the app using dotnet watch for live reload (binds to 0.0.0.0 to listen on all network interfaces)
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]

