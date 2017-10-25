FROM microsoft/aspnetcore-build AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish --output /app/ --configuration Release

# Build runtime image
FROM microsoft/aspnetcore:1.1
WORKDIR /app
LABEL MAINTAINER="baynezy@gmail.com"
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "Contentment.Api.dll"]