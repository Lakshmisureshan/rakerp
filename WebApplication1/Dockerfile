# Use the official .NET SDK image to build and publish the app
# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# Choose the appropriate SDK version (e.g., 6.0, 7.0, 8.0) based on your project's target framework

WORKDIR /app

# Copy the .csproj file first to restore dependencies
# This optimizes Docker caching: if only source code changes, dependencies aren't re-restored
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code
COPY . ./

# Publish the application, building into 'out' directory
RUN dotnet publish -c Release -o out

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
# Choose the appropriate ASP.NET Runtime version (e.g., 6.0, 7.0, 8.0)
# This should match the SDK version used in the build stage and your project's target framework

WORKDIR /app


# Copy the published output from the build-env stage
COPY --from=build-env /app/out .

# Expose the port Kestrel listens on (default for HTTP is 80)
EXPOSE 80

# Define the entry point for the application
# Replace 'YourApiProjectName.dll' with the actual name of your project's DLL file
# For example, if your .csproj is named 'MyBackend.csproj', the DLL will be 'MyBackend.dll'
ENTRYPOINT ["dotnet", "WebApplication1.dll"]