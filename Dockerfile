##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["EntityLayer.csproj", "Entity/"]
#COPY ["DataAccessLayer.csproj", "DataAccessLayer/"]
#COPY ["BusinessLayer.csproj", "BusinessLayer/"]
#COPY ["RentaCar/RentaCar.csproj", "RentaCar/"]
#
#
#RUN dotnet restore "RentaCar/RentaCar.csproj"
#COPY . .
#WORKDIR "/src/RentaCar"
#RUN dotnet build "RentaCar.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "RentaCar.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "RentaCar.dll"]



#FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
#WORKDIR /app
#
#
## Copy everything else and build
#COPY . ./
#RUN dotnet restore
#RUN dotnet publish -o out /app/published-app
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
#WORKDIR /app
#COPY --from=build /app/publish-app /app
#
#EXPOSE 7096
#ENTRYPOINT ["dotnet", "Rentcar.dll"]



# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 7096
ENTRYPOINT ["dotnet", "Rentcar.dll"]

