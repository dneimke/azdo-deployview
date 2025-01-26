# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Install Node.js and npm for frontend development (if needed)
# You can choose a specific version of Node.js if required
USER root
RUN apt-get update && \
    apt-get install -y wget && \
    wget -O /tmp/powershell.deb https://github.com/PowerShell/PowerShell/releases/download/v7.4.1/powershell_7.4.1-1.deb_amd64.deb && \
    dpkg -i /tmp/powershell.deb && \
    rm -rf /tmp/powershell.deb

# If you are using a database, you may need to add commands to install necessary
# database clients or tools here. For example, to install the PostgreSQL client:
# RUN apt-get update && apt-get install -y postgresql-client

# (Optional) Install other useful tools
# For example: Git, debugging tools, etc.
# RUN apt-get update && apt-get install -y git

# Copy the application files to the container (if you want to build within the container)
# Consider using a .dockerignore file to exclude unnecessary files/folders.
# COPY . .

# Expose the port that your ASP.NET application will listen on
# EXPOSE 5000
# EXPOSE 5001

# Define environment variables (if needed)
# ENV ASPNETCORE_ENVIRONMENT=Development
# ENV ConnectionStrings__DefaultConnection="your_connection_string"

# Set the entry point (you can customize this based on your project's needs)
# If you want to build inside the container, you can add build commands here or
# you can add commands like hot-reloading, etc.
# CMD