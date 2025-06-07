# Stage 1: Building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file first and restore dependencies.
# This is a Docker optimization. If only code files change later,
# this layer can be reused from cache, speeding up builds.
COPY McpServer/McpServer.csproj ./
RUN dotnet restore

# Copy the rest of the app's code
COPY McpServer/. ./

# # Publish the application (AFTER FINISHING DEVELOPMENT)
# RUN dotnet publish -c Release -o /app/publish

# # ------------------------

# # Stage 2: Running the app (AFTER FINISHED DEVELOPMENT)
# # Use a smaller .net runtime image
# FROM mcr.microsoft.com/dotnet/runtime:8.0
# WORKDIR /app

# # Copy the published app from the preivous stage
# COPY --from=build /app/publish .

# # Set an initial comand that keeps the container alive.
# # Explanation: this is a Linux command that essentially does nothing, forever. 
# # Claude Desktop (or any other client) will be the responsible of running the app. 
# # Note: I think this is kind of a weird workaround a weird problem i was facing, might find an alternative later
ENTRYPOINT ["tail", "-f", "/dev/null"]