FROM ubuntu:latest
LABEL authors="maciucateodor"

RUN apt update && \
    apt-get install -y sudo openssl libssl-dev vim g++ && \
    rm -rf /var/lib/apt/lists/*

COPY Proxy /home/Proxy

WORKDIR /home/Proxy

RUN g++ main.cpp -o software_engineering_product_topteam -I/usr/include/openssl -L/usr/lib/x86_64-linux-gnu -lssl -lcrypto

#CMD ["./software_engineering_product_topteam"]
