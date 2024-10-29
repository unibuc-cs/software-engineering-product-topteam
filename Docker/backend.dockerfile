# Base image - using Ubuntu as specified
FROM ubuntu:latest
LABEL authors="maciucateodor"

# Install dependencies including .NET SDK and required packages
RUN apt update && \
    apt-get install -y sudo openssl libssl-dev vim g++ ufw openssh-server wireguard wget && \
    rm -rf /var/lib/apt/lists/*

# Install the .NET SDK
RUN wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    sudo dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb && \
    sudo apt update && \
    sudo apt install -y dotnet-sdk-7.0

# Set up SSH (for potential debugging purposes)
RUN mkdir /var/run/sshd
RUN echo 'root:password' | chpasswd
RUN sed -i 's/#PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config
RUN sed -i 's/#PasswordAuthentication yes/PasswordAuthentication yes/' /etc/ssh/sshd_config

# Configure firewall rules to allow only WireGuard port
RUN sudo ufw allow 51820/udp && \
    echo "y" | ufw enable

# Set up ASP.NET Core application
# Copy the .NET application files to the container
COPY backend-MT /home/backend-MT
WORKDIR /home/backend-MT

# Install necessary .NET packages (if not already included in the project)
RUN dotnet add package Microsoft.EntityFrameworkCore --version 7.0.20 && \
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.20 && \
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 7.0.20 && \
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# Create initial migration and update database
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations add InitialCreate && \
    dotnet ef database update

# Publish the .NET application
RUN dotnet publish --configuration Release --output /home/backend-MT/publish

# Expose only WireGuard port
EXPOSE 51820/udp

# Start WireGuard service and the application
CMD service ssh start && \
    dotnet /home/backend-MT/publish/backend-MT.dll
