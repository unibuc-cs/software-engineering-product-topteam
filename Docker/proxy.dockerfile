FROM ubuntu:latest
LABEL authors="maciucateodor"

RUN apt update && \
    apt-get install -y sudo openssl libssl-dev vim g++ ufw openssh-server && \
    rm -rf /var/lib/apt/lists/*

RUN mkdir /var/run/sshd
RUN echo 'root:password' | chpasswd
RUN sed -i 's/#PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config
RUN sed -i 's/#PasswordAuthentication yes/PasswordAuthentication yes/' /etc/ssh/sshd_config

RUN sudo ufw allow 443/tcp
RUN sudo ufw allow 8443/tcp
RUN sudo ufw allow 80/tcp
RUN sudo ufw allow 8080/tcp
RUN sudo ufw allow 22/tcp
RUN sudo ufw limit 22/tcp
RUN echo "y" | ufw enable

COPY Proxy /home/Proxy

WORKDIR /home/Proxy

RUN g++ main.cpp -o software_engineering_product_topteam -I/usr/include/openssl -L/usr/lib/x86_64-linux-gnu -lssl -lcrypto

EXPOSE 22 443 8443 80 8080

CMD service ssh start && ./software_engineering_product_topteam
