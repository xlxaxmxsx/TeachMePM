FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 62580
EXPOSE 44322

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TeachMeNET/TeachMeNET.csproj", "TeachMeNET/"]
RUN dotnet restore "TeachMeNET/TeachMeNET.csproj"
COPY . .
WORKDIR "/src/TeachMeNET"
RUN dotnet build "TeachMeNET.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TeachMeNET.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TeachMeNET.dll"]