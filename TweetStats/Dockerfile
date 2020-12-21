#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TweetStats/TweetStats.csproj", "TweetStats/"]
COPY ["TweetStats.Data/TweetStats.Data.csproj", "TweetStats.Data/"]
RUN dotnet restore "TweetStats/TweetStats.csproj"
COPY . .
WORKDIR "/src/TweetStats"
RUN dotnet build "TweetStats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TweetStats.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TweetStats.dll"]