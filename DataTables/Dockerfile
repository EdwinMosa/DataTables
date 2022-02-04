# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY bin/Release/net5.0/ App/

WORKDIR /App
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "datatables.dll"]