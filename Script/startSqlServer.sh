#!/bin/bash

isRunning=sudo docker inspect sql_server | grep -q '"Running": false,'
if $isRunning;
then
    sudo docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=password123!' -p 1433:1433 microsoft/mssql-server-linux
    cd ..
    sudo dotnet ef database update -v
else 
    echo "sql_server is running."
fi

