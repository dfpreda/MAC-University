#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MAC University/MAC.csproj", "MAC University/"]
COPY ["MAC.Services/MAC.Services.csproj", "MAC.Services/"]
COPY ["MAC.Data/MAC.Data.csproj", "MAC.Data/"]
COPY ["MAC.Data.Entities/MAC.Data.Entities.csproj", "MAC.Data.Entities/"]
COPY ["MAC.Data.Abstractions/MAC.Data.Abstractions.csproj", "MAC.Data.Abstractions/"]
COPY ["MAC.Data.DTO/MAC.Data.DTO.csproj", "MAC.Data.DTO/"]
RUN dotnet restore "MAC University/MAC.csproj"
COPY . .
WORKDIR "/src/MAC University"
RUN dotnet build "MAC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MAC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MAC.dll"]