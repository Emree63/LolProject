#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiLol/ApiLol.csproj", "ApiLol/"]
COPY ["StubLib/StubLib.csproj", "StubLib/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["DTO/DTO.csproj", "DTO/"]
RUN dotnet restore "ApiLol/ApiLol.csproj"
COPY . .
WORKDIR "/src/ApiLol"
RUN dotnet build "ApiLol.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiLol.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiLol.dll"]