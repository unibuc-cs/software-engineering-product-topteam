FROM ubuntu:latest
LABEL authors="maciucateodor"

# Install dependencies and WireGuard
RUN apt update && \
    apt-get install -y sudo openssl libssl-dev vim g++ ufw openssh-server wireguard && \
    rm -rf /var/lib/apt/lists/*

# Set up SSH for remote access
RUN mkdir /var/run/sshd
RUN echo 'root:password' | chpasswd
RUN sed -i 's/#PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config
RUN sed -i 's/#PasswordAuthentication yes/PasswordAuthentication yes/' /etc/ssh/sshd_config

# Configure firewall rules with UFW
RUN sudo ufw allow 443/tcp && \
    sudo ufw allow 8443/tcp && \
    sudo ufw allow 80/tcp && \
    sudo ufw allow 8080/tcp && \
    sudo ufw allow 22/tcp && \
    sudo ufw limit 22/tcp && \
    sudo ufw allow 51820/udp && \
    echo "y" | ufw enable

# Copy and set up the proxy application
COPY Proxy /home/Proxy
WORKDIR /home/Proxy

# Compile the proxy application
RUN g++ main.cpp -o software_engineering_product_topteam -I/usr/include/openssl -L/usr/lib/x86_64-linux-gnu -lssl -lcrypto

# Expose necessary ports
EXPOSE 22 443 8443 80 8080 51820/udp

# Start SSH and the proxy application
CMD service ssh start && ./software_engineering_product_topteam
