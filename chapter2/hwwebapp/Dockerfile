FROM microsoft/dotnet:latest 
COPY bin/Release/netcoreapp2.0/publish/ /root/ 
EXPOSE 5000/tcp 1 
ENTRYPOINT dotnet /root/hwwebapp.dll