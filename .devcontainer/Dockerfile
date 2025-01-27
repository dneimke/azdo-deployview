# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Install Node.js and npm for frontend development (if needed)
USER root
RUN apt-get update && \
    apt-get install -y wget && \
    wget -O /tmp/powershell.deb https://github.com/PowerShell/PowerShell/releases/download/v7.4.1/powershell_7.4.1-1.deb_amd64.deb && \
    dpkg -i /tmp/powershell.deb && \
    rm -rf /tmp/powershell.deb

# Install Azure CLI
RUN curl -sL https://aka.ms/InstallAzureCLIDeb | bash

RUN apt-get update && apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs && \
    npm install -g azure-functions-core-tools@4 --unsafe-perm true

# Create the user
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

RUN groupadd --gid $USER_GID $USERNAME \
    && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME \
    && apt-get update \
    && apt-get install -y sudo \
    && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
    && chmod 0440 /etc/sudoers.d/$USERNAME

# Switch to non-root user by default
USER $USERNAME

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