FROM centos:7 AS base

# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

ENV DOTNET_URLS=http://+:5137

# Copy the solution file and restore dependencies
COPY BluePillCRM.Application.WebApi.sln ./
COPY BluePillCRM.Application.WebApi/BluePillCRM.Application.WebApi.csproj ./BluePillCRM.Application.WebApi/
COPY BluePillCRM.Datas.DbContext/BluePillCRM.Datas.DbContext.csproj ./BluePillCRM.Datas.DbContext/
COPY BluePillCRM.Datas.Entities/BluePillCRM.Datas.Entities.csproj ./BluePillCRM.Datas.Entities/
COPY BluePillCRM.Business.Repository/BluePillCRM.Business.Repository.csproj ./BluePillCRM.Business.Repository/
COPY BluePillCRM.Business.Services/BluePillCRM.Business.Services.csproj ./BluePillCRM.Business.Services/
COPY BluePillCRM.Business.Dtos/BluePillCRM.Business.Dtos.csproj ./BluePillCRM.Business.Dtos/
COPY BluePillCRM.Application.Ioc/BluePillCRM.Application.Ioc.csproj ./BluePillCRM.Application.Ioc/
# Add other project files as needed

RUN dotnet restore

RUN apt-get update && apt-get install -y \
curl
CMD /bin/bash

# Copy the entire project directory and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Download and install the .NET 7.0 runtime
ADD https://dotnetcli.blob.core.windows.net/dotnet/Runtime/7.0.0/dotnet-runtime-7.0.0-linux-arm64.tar.gz .
RUN tar -xf dotnet-runtime-7.0.0-linux-arm64.tar.gz && \
    rm dotnet-runtime-7.0.0-linux-arm64.tar.gz

# Expose the port
EXPOSE 5137

# Set the entry point
ENTRYPOINT ["dotnet", "BluePillCRM.Application.WebApi.dll"]