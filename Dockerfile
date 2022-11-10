# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /bin/release/net6.0
COPY bin/release/net6.0 ./
ENTRYPOINT ["dotnet", "SaveApp.dll"]