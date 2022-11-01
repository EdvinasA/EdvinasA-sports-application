# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /

# copy everything else and build app
COPY / .
WORKDIR /
RUN dotnet publish -c release -o /out --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /bin/Release/net6.0
COPY /bin/Release/net6.0 ./
ENTRYPOINT ["dotnet", "SaveApp.dll"]