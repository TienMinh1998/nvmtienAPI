#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["APIProject/APIProject.csproj", "APIProject/"]
COPY ["APIProject.Common/APIProject.Common.csproj", "APIProject.Common/"]
COPY ["APIProject.Domain/APIProject.Domain.csproj", "APIProject.Domain/"]
COPY ["APIProject.Service/APIProject.Service.csproj", "APIProject.Service/"]
COPY ["APIProject.Repository/APIProject.Repository.csproj", "APIProject.Repository/"]
RUN dotnet restore "APIProject/APIProject.csproj"
COPY . .
WORKDIR "/src/APIProject"
RUN dotnet build "APIProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIProject.dll"]
