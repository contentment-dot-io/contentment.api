FROM microsoft/aspnetcore-build AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish --output /source/ --configuration Release

# Build runtime image
FROM microsoft/aspnetcore:1.1
WORKDIR /app
LABEL MAINTAINER="baynezy@gmail.com"
COPY --from=build-env /source .
ENTRYPOINT ["dotnet", "Contentment.Api.dll"]